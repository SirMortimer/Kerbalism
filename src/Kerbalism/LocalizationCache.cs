using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSP.Localization;
using System.Text.RegularExpressions;

namespace KERBALISM
{
	// Localization cache
	public static class Local
	{
		private const string prefix = "#KERBALISM_";
		private static string GetLoc(string template) => Localizer.Format(prefix + template);

		// utility method for development, will generate a localization config template based on the contents of this file
		// Note that this assume that parametrized strings (using <<x>>) are put as comments in this file with the following format :
		// #KERBALISM_BodyInfo_BodyInfoToggleHelp "Press <<1>> to open this window again"
		static void GenerateLocTemplate(bool english = false)
		{
			string[] localCachelines = System.IO.File.ReadAllLines(@"C:\Users\Got\source\repos\Kerbalism\Kerbalism\src\Kerbalism\LocalizationCache.cs");
			List<string> locFile = new List<string>();
			foreach (string line in localCachelines)
			{
				// public static string (.*?) = GetLoc.*//.*?"(.*)"
				Match locMatch = Regex.Match(line, "public static string (.*?) = GetLoc.*//.*?\"(.*)\"");
				if (locMatch.Success)
				{
					if (english)
						locFile.Add("#KERBALISM_" + locMatch.Groups[1].Value + " = " + locMatch.Groups[2].Value);
					else
						locFile.Add("#KERBALISM_" + locMatch.Groups[1].Value + " = " + "// \"" + locMatch.Groups[2].Value + "\"");
					
					continue;
				}

				// //.*(#.*?) .*?"(.*<<.*>>.*)"
				Match parameterLocMatch = Regex.Match(line, "//.*(#.*?) .*?\"(.*<<.*>>.*)\"");
				if (parameterLocMatch.Success)
				{
					if (english)
						locFile.Add(parameterLocMatch.Groups[1].Value + " = " + parameterLocMatch.Groups[2].Value);
					else
						locFile.Add(parameterLocMatch.Groups[1].Value + " = " + "// \"" + parameterLocMatch.Groups[2].Value + "\"");
					continue;
				}

				// .*(//.*)
				Match commentMatch = Regex.Match(line, ".*(//.*)");
				if (commentMatch.Success)
				{
					locFile.Add(commentMatch.Groups[1].Value);
					continue;
				}
			}
			System.IO.File.WriteAllLines(@"C:\Users\Got\Desktop\loctest\loctemplate.txt", locFile);
		}

		////////////////////////////////////////////////////////////////////
		// START OF LOCALIZATION FIELDS
		////////////////////////////////////////////////////////////////////

		////////////////////////////////////////////////////////////////////
		// PartModules PAW UI Groups
		////////////////////////////////////////////////////////////////////
		public static string Group_Science = GetLoc("Group_Science"); // "Science"
		public static string Group_Greenhouse = GetLoc("Group_Greenhouse"); // "Greenhouse"
		public static string Group_Habitat = GetLoc("Group_Habitat"); // "Habitat"
		public static string Group_Radiation = GetLoc("Group_Radiation"); // "Radiation"
		public static string Group_Configuration = GetLoc("Group_Configuration"); // "Configuration"
		public static string Group_Processes = GetLoc("Group_Processes"); // "Processes"
		public static string Group_Reliability = GetLoc("Group_Reliability"); // "Reliability"
		public static string Group_Sensors = GetLoc("Group_Sensors"); // "Sensors"

		////////////////////////////////////////////////////////////////////
		// Generic strings
		////////////////////////////////////////////////////////////////////
		public static string Generic_ON = GetLoc("Generic_ON"); // "on"
		public static string Generic_OFF = GetLoc("Generic_OFF"); // "off"
		public static string Generic_ENABLED = GetLoc("Generic_ENABLED"); // "enabled"
		public static string Generic_DISABLED = GetLoc("Generic_DISABLED"); // "disabled"
		public static string Generic_ACTIVE = GetLoc("Generic_ACTIVE"); // "active"
		public static string Generic_INACTIVE = GetLoc("Generic_INACTIVE"); // "inactive"
		public static string Generic_ALWAYSON = GetLoc("Generic_ALWAYSON"); // "always on"
		public static string Generic_RECORDING = GetLoc("Generic_RECORDING"); // "recording"
		public static string Generic_STOPPED = GetLoc("Generic_STOPPED"); // "stopped"
		public static string Generic_RUNNING = GetLoc("Generic_RUNNING"); // "running"
		public static string Generic_EXTENDED = GetLoc("Generic_EXTENDED"); // "extended"
		public static string Generic_RETRACTED = GetLoc("Generic_RETRACTED"); // "retracted"
		public static string Generic_DEPLOYED = GetLoc("Generic_DEPLOYED"); // "extended"
		public static string Generic_BROKEN = GetLoc("Generic_BROKEN"); // "broken"
		public static string Generic_EXTENDING = GetLoc("Generic_EXTENDING"); // "extending"
		public static string Generic_RETRACTING = GetLoc("Generic_RETRACTING"); // "retracting"
		public static string Generic_YES = GetLoc("Generic_YES"); // "yes"
		public static string Generic_NO = GetLoc("Generic_NO"); // "no"
		public static string Generic_RETRACT = GetLoc("Generic_RETRACT"); // "retract"
		public static string Generic_DEPLOY = GetLoc("Generic_DEPLOY"); // "deploy"
		public static string Generic_FROM = GetLoc("Generic_FROM"); // "from"
		public static string Generic_TO = GetLoc("Generic_TO"); // "to"
		public static string Generic_NONE = GetLoc("Generic_NONE"); // "none"
		public static string Generic_NOTHING = GetLoc("Generic_NOTHING"); // "nothing"
		public static string Generic_SLOTS = GetLoc("Generic_SLOTS"); // "slots"
		public static string Generic_SLOT = GetLoc("Generic_SLOT"); // "slot"
		public static string Generic_AVERAGE = GetLoc("Generic_AVERAGE"); // "average"
		public static string Generic_notdeployed = GetLoc("Generic_notdeployed"); // "not deployed"
		public static string Generic_PERPETUAL = GetLoc("Generic_PERPETUAL"); // "perpetual"
		public static string Generic_NEVER = GetLoc("Generic_NEVER"); // "never"
		public static string Generic_NOMINAL = GetLoc("Generic_NOMINAL"); // "nominal"
		//$HIS_HER
		public static string Kerbal_his = GetLoc("Kerbal_his"); // "his"
		public static string Kerbal_her = GetLoc("Kerbal_her"); // "her"

		////////////////////////////////////////////////////////////////////
		// Hardcoded resource brokers (consumers/producers) localization
		// Shown in the resource telemetry tooltip
		////////////////////////////////////////////////////////////////////
		public static string Brokers_Others = GetLoc("Brokers_Others"); // "others"
		public static string Brokers_SolarPanel = GetLoc("Brokers_SolarPanel"); // "solar panel"
		public static string Brokers_KSPIEGenerator = GetLoc("Brokers_KSPIEGenerator"); // "KSPIE generator"
		public static string Brokers_FissionReactor = GetLoc("Brokers_FissionReactor"); // "fission generator"
		public static string Brokers_RTG = GetLoc("Brokers_RTG"); // "radioisotope generator"
		public static string Brokers_ScienceLab = GetLoc("Brokers_ScienceLab"); // "science lab"
		public static string Brokers_Light = GetLoc("Brokers_Light"); // "light"
		public static string Brokers_Boiloff = GetLoc("Brokers_Boiloff"); // "boiloff"
		public static string Brokers_Cryotank = GetLoc("Brokers_Cryotank"); // "cryo tank"
		public static string Brokers_Greenhouse = GetLoc("Brokers_Greenhouse"); // "greenhouse"
		public static string Brokers_Deploy = GetLoc("Brokers_Deploy"); // "deploy"
		public static string Brokers_Experiment = GetLoc("Brokers_Experiment"); // "experiment"
		public static string Brokers_Command = GetLoc("Brokers_Command"); // "command"
		public static string Brokers_GravityRing = GetLoc("Brokers_GravityRing"); // "gravity ring"
		public static string Brokers_Scanner = GetLoc("Brokers_Scanner"); // "scanner"
		public static string Brokers_Laboratory = GetLoc("Brokers_Laboratory"); // "laboratory"
		public static string Brokers_CommsIdle = GetLoc("Brokers_CommsIdle"); // "comms (idle)"
		public static string Brokers_CommsXmit = GetLoc("Brokers_CommsXmit"); // "comms (xmit)"
		public static string Brokers_StockConverter = GetLoc("Brokers_StockConverter"); // "converter"
		public static string Brokers_StockDrill = GetLoc("Brokers_StockDrill"); // "drill"
		public static string Brokers_Harvester = GetLoc("Brokers_Harvester"); // "harvester"

		////////////////////////////////////////////////////////////////////
		//Contracts
		////////////////////////////////////////////////////////////////////
		public static string Contracts_radTitle = GetLoc("Contracts_radTitle"); // "Cross the radiation belt"
		public static string Contracts_radDesc = GetLoc("Contracts_radDesc"); // "A brilliant scientist predicted two belts of super-charged particles surrounding the planet. Now we need to confirm their existence and find out how deadly they really are."
		public static string Contracts_radComplete = GetLoc("Contracts_radComplete"); // "The mission confirmed the presence of two radiation belts around the planet. Early data suggest extreme levels of radiation."
		public static string Contracts_heliopauseTitle = GetLoc("Contracts_heliopauseTitle"); // "Cross the heliopause"
		public static string Contracts_heliopauseDesc = GetLoc("Contracts_heliopauseDesc"); // "What is out there, beyond the heliopause? The truth is, we don't know. That's where you come in."
		public static string Contracts_heliopauseComplete = GetLoc("Contracts_heliopauseComplete"); // "We went so far the mind doesn't comprehend it. Beyond the heliopause there are the wonders of interstellar space, and more radiation."
		public static string Contracts_orbitTitle = GetLoc("Contracts_orbitTitle"); // "Put a Kerbal in orbit for 30 days"
		public static string Contracts_orbitDesc = GetLoc("Contracts_orbitDesc"); // "Obtaining an orbit was easier than we expected. Now it is time to keep a Kerbal alive in orbit for 30 days."
		public static string Contracts_orbitComplete = GetLoc("Contracts_orbitComplete"); // "The mission was a success, albeit the Kerbal is a bit bored. We have plenty of data about long-term permanence in space."
		public static string Contracts_foodTitle = GetLoc("Contracts_foodTitle"); // "Harvest food in space"
		public static string Contracts_foodDesc = GetLoc("Contracts_foodDesc"); // ""Now that we got the technology to grow food in space, we should probably test it. Harvest food from a greenhouse in space."
		public static string Contracts_foodComplete = GetLoc("Contracts_foodComplete"); // "We harvested food in space, and our scientists says it is actually delicious."
		public static string Contracts_sampleTitle = GetLoc("Contracts_sampleTitle"); // "Analyze samples in space"
		public static string Contracts_sampleDesc = GetLoc("Contracts_sampleDesc"); // "The Laboratory can analyze samples in space, in theory. We should check if this actually work by and analyzing some samples in space."
		public static string Contracts_sampleComplete = GetLoc("Contracts_sampleComplete"); // "Our Laboratory analysis was good, perhaps even better than the ones done usually by our scientists at mission control. But don't tell'em."

		////////////////////////////////////////////////////////////////////
		// Body info UI
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_BodyInfo_BodyInfoToggleHelp "Press <<1>> to open this window again"
		// #KERBALISM_BodyInfo_stormcycle "<<1>> cycle"
		public static string BodyInfo_title = GetLoc("BodyInfo_title"); // "BODY INFO"
		public static string BodyInfo_SURFACE = GetLoc("BodyInfo_SURFACE"); // "SURFACE"
		public static string BodyInfo_temperature = GetLoc("BodyInfo_temperature"); // "temperature"
		public static string BodyInfo_solarflux = GetLoc("BodyInfo_solarflux"); // "solar flux"
		public static string BodyInfo_radiation = GetLoc("BodyInfo_radiation"); // "radiation"
		public static string BodyInfo_ATMOSPHERE = GetLoc("BodyInfo_ATMOSPHERE"); // "ATMOSPHERE"
		public static string BodyInfo_breathable = GetLoc("BodyInfo_breathable"); // "breathable"
		public static string BodyInfo_breathable_yes = GetLoc("BodyInfo_breathable_yes"); // "yes"
		public static string BodyInfo_breathable_no = GetLoc("BodyInfo_breathable_no"); // "no"
		public static string BodyInfo_lightabsorption = GetLoc("BodyInfo_lightabsorption"); // "light absorption"
		public static string BodyInfo_gammaabsorption = GetLoc("BodyInfo_gammaabsorption"); // "gamma absorption"
		public static string BodyInfo_RADIATION = GetLoc("BodyInfo_RADIATION"); // "RADIATION"
		public static string BodyInfo_solaractivity = GetLoc("BodyInfo_solaractivity"); // "solar activity"
		public static string BodyInfo_radiationonsurface = GetLoc("BodyInfo_radiationonsurface"); // "radiation on surface:"
		public static string BodyInfo_innerbelt = GetLoc("BodyInfo_innerbelt"); // "inner belt: "
		public static string BodyInfo_outerbelt = GetLoc("BodyInfo_outerbelt"); // "outer belt: "
		public static string BodyInfo_magnetopause = GetLoc("BodyInfo_magnetopause"); // "magnetopause:"
		public static string BodyInfo_show = GetLoc("BodyInfo_show"); // "show"
		public static string BodyInfo_hide = GetLoc("BodyInfo_hide"); // "hide"
		public static string BodyInfo_unknown = GetLoc("BodyInfo_unknown"); // "unknown"

		////////////////////////////////////////////////////////////////////
		// Monitor UI
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Monitor_GoComfirm // "Do you really want go to <<1>> vessel?"
		public static string Monitor_novessels = GetLoc("Monitor_novessels"); // "no vessels"
		public static string Monitor_Gotovessel = GetLoc("Monitor_Gotovessel"); // "Go to vessel!"
		public static string Monitor_Warning_title = GetLoc("Monitor_Warning_title"); // "Warning!"
		public static string Monitor_GoComfirm_button1 = GetLoc("Monitor_GoComfirm_button1"); // "Go"
		public static string Monitor_GoComfirm_button2 = GetLoc("Monitor_GoComfirm_button2"); // "Target"
		public static string Monitor_GoComfirm_button3 = GetLoc("Monitor_GoComfirm_button3"); // "Stay"
		public static string Monitor_tooltip = GetLoc("Monitor_tooltip"); // "\n<i>(middle-click to popout in a window, middle-click again to close popout)</i>"
		public static string Monitor_INFO = GetLoc("Monitor_INFO"); // "INFO"
		public static string Monitor_INFO_desc = GetLoc("Monitor_INFO_desc"); // "Telemetry readings"
		public static string Monitor_DATA = GetLoc("Monitor_DATA"); // "DATA"
		public static string Monitor_DATA_desc = GetLoc("Monitor_DATA_desc"); // "Stored files and samples"
		public static string Monitor_AUTO = GetLoc("Monitor_AUTO"); // "AUTO"
		public static string Monitor_AUTO_desc = GetLoc("Monitor_AUTO_desc"); // "Control and automate components"
		public static string Monitor_FAILURES = GetLoc("Monitor_FAILURES"); // "FAILURES"
		public static string Monitor_FAILURES_desc = GetLoc("Monitor_FAILURES_desc"); // "See failures and maintenance state"
		public static string Monitor_LOG = GetLoc("Monitor_LOG"); // "LOG"
		public static string Monitor_LOG_desc = GetLoc("Monitor_LOG_desc"); // "See previous notifications"
		public static string Monitor_CFG = GetLoc("Monitor_CFG"); // "CFG"
		public static string Monitor_CFG_desc = GetLoc("Monitor_CFG_desc"); // "Configure the vessel"
		public static string Monitor_Inshadow = GetLoc("Monitor_Inshadow"); // "In shadow"
		public static string Monitor_Greenhouse = GetLoc("Monitor_Greenhouse"); // "Greenhouse:"
		public static string Monitor_ExposedRadiation1 = GetLoc("Monitor_ExposedRadiation1"); // "Exposed to extreme radiation"
		public static string Monitor_ExposedRadiation2 = GetLoc("Monitor_ExposedRadiation2"); // "Exposed to intense radiation"
		public static string Monitor_ExposedRadiation3 = GetLoc("Monitor_ExposedRadiation3"); // "Exposed to moderate radiation"
		public static string Monitor_CO2level = GetLoc("Monitor_CO2level"); // "CO2 level in internal atmosphere:"
		public static string Monitor_ejectionincoming = GetLoc("Monitor_ejectionincoming"); // "Coronal mass ejection incoming"
		public static string Monitor_TimetoimpactCoronalmass = GetLoc("Monitor_TimetoimpactCoronalmass"); // "Time to impact:"
		public static string Monitor_Solarstorminprogress = GetLoc("Monitor_Solarstorminprogress"); // "Solar storm in progress"
		public static string Monitor_SolarstormRemaining = GetLoc("Monitor_SolarstormRemaining"); // "Remaining duration:"
		public static string Monitor_name = GetLoc("Monitor_name"); // "name"
		public static string Monitor_level = GetLoc("Monitor_level"); // "level"
		public static string Monitor_duration = GetLoc("Monitor_duration"); // "duration"
		public static string Monitor_depleted = GetLoc("Monitor_depleted"); // "depleted"
		public static string Monitor_Malfunctions = GetLoc("Monitor_Malfunctions"); // "Malfunctions"
		public static string Monitor_Criticalfailures = GetLoc("Monitor_Criticalfailures"); // "Critical failures"

		////////////////////////////////////////////////////////////////////
		// Telemetry/Planner UI : Signal
		////////////////////////////////////////////////////////////////////
		public static string UI_signallost = GetLoc("UI_signallost"); // "Signal lost with"
		public static string UI_signalback = GetLoc("UI_signalback"); // "signal is back"
		public static string UI_relayby = GetLoc("UI_relayby"); // "Relayed by"
		public static string UI_directlink = GetLoc("UI_directlink"); // "We got a direct link with the space center"
		public static string UI_noctrl = GetLoc("UI_noctrl"); // "Remote control disabled"
		public static string UI_limitedcontrol = GetLoc("UI_limitedcontrol"); // "Limited control available"
		public static string UI_telemetry = GetLoc("UI_telemetry"); // "telemetry"
		public static string UI_DSNconnected = GetLoc("UI_DSNconnected"); // "DSN connected"
		public static string UI_sciencerate = GetLoc("UI_sciencerate"); // "science rate"
		public static string UI_strength = GetLoc("UI_strength"); // "strength"
		public static string UI_target = GetLoc("UI_target"); // "target"
		public static string UI_transmitting = GetLoc("UI_transmitting"); // "transmitting"
		public static string UI_Signalrelayed = GetLoc("UI_Signalrelayed"); // "Signal relayed"
		public static string UI_Plasmablackout = GetLoc("UI_Plasmablackout"); // "Plasma blackout"
		public static string UI_Stormblackout = GetLoc("UI_Stormblackout"); // "Storm blackout"
		public static string UI_transmissiondisabled = GetLoc("UI_transmissiondisabled"); // "Data transmission disabled"

		////////////////////////////////////////////////////////////////////
		// Telemetry/Planner UI : Automation
		////////////////////////////////////////////////////////////////////
		public static string UI_devman = GetLoc("UI_devman"); // "DEV MANAGER"
		public static string UI_devices = GetLoc("UI_devices"); // "DEVICES"
		public static string UI_dontcare = GetLoc("UI_dontcare"); // "don't care"
		public static string UI_scriptvessel = GetLoc("UI_scriptvessel"); // "Script called on vessel"
		public static string DevManager_VESSELDEVICES = GetLoc("DevManager_VESSELDEVICES"); // "VESSEL DEVICES"
		public static string DevManager_MODULEDEVICES = GetLoc("DevManager_MODULEDEVICES"); // "MODULE DEVICES"
		public static string DevManager_nodevices = GetLoc("DevManager_nodevices"); // "no devices"

		////////////////////////////////////////////////////////////////////
		// Telemetry/Planner UI : Comfort
		////////////////////////////////////////////////////////////////////
		public static string Comfort_firmground = GetLoc("Comfort_firmground"); // "firm ground"
		public static string Comfort_exercise = GetLoc("Comfort_exercise"); // "exercise"
		public static string Comfort_notalone = GetLoc("Comfort_notalone"); // "not alone"
		public static string Comfort_callhome = GetLoc("Comfort_callhome"); // "call home"
		public static string Comfort_panorama = GetLoc("Comfort_panorama"); // "panorama"
		public static string Comfort_factor = GetLoc("Comfort_factor"); // "factor"
		public static string Comfort_plants = GetLoc("Comfort_plants"); // "plants"
		public static string Configure_noconfigure = GetLoc("Configure_noconfigure"); // "Can't reconfigure the component"
		public static string Configure_dumpexcess = GetLoc("Configure_dumpexcess"); // "Reconfiguring will dump resources in excess of capacity."
		public static string Science_ofdatatransfer = GetLoc("Science_ofdatatransfer"); // "of data transfered"
		public static string Science_inoperable = GetLoc("Science_inoperable"); // "The experiment is now inoperable, resetting will require a <b>Scientist</b>"

		////////////////////////////////////////////////////////////////////
		// Telemetry/Planner UI : CONNECTION MANAGER
		////////////////////////////////////////////////////////////////////
		public static string ConnManager_title = GetLoc("ConnManager_title"); // "CONNECTION MANAGER"
		public static string ConnManager_CONTROLPATH = GetLoc("ConnManager_CONTROLPATH"); // "CONTROL PATH"
		public static string ConnManager_noconnection = GetLoc("ConnManager_noconnection"); // "no connection"

		////////////////////////////////////////////////////////////////////
		// Telemetry/Planner UI : reliability / quality
		////////////////////////////////////////////////////////////////////
		public static string QualityManagement_title = GetLoc("QualityManagement_title"); // "Quality Management"
		public static string QualityManagement_noqualityinfo = GetLoc("QualityManagement_noqualityinfo"); // "no quality info"
		public static string QualityManagement_Misc = GetLoc("QualityManagement_Misc"); // "Misc"
		public static string QualityManagement_busted = GetLoc("QualityManagement_busted"); // "busted"
		public static string QualityManagement_needsrepair = GetLoc("QualityManagement_needsrepair"); // "needs repair"
		public static string QualityManagement_needsservice = GetLoc("QualityManagement_needsservice"); // "needs service"
		public static string QualityManagement_operationduration = GetLoc("QualityManagement_operationduration"); // "operation duration"
		public static string QualityManagement_ignitionlimit = GetLoc("QualityManagement_ignitionlimit"); // "ignition limit"
		public static string QualityManagement_good = GetLoc("QualityManagement_good"); // "good"

		////////////////////////////////////////////////////////////////////
		// Monitor UI : file manager
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_FILEMANAGER_DataAvailable // "(<<1>> available)"
		// #KERBALISM_FILEMANAGER_SAMPLESMass // "SAMPLES <<1>>"
		// #KERBALISM_FILEMANAGER_TransmittingRate // "Transmitting at <<1>>"
		// #KERBALISM_FILEMANAGER_DeleteConfirm // "Do you really want to delete <<1>>?"
		// #KERBALISM_FILEMANAGER_DumpConfirm // "Do you really want to dump <<1>>?"
		public static string FILEMANAGER_title = GetLoc("FILEMANAGER_title"); // "FILE MANAGER"
		public static string FILEMANAGER_DataCapacity = GetLoc("FILEMANAGER_DataCapacity"); // "DATA"
		public static string FILEMANAGER_nofiles = GetLoc("FILEMANAGER_nofiles"); // "no files"
		public static string FILEMANAGER_SAMPLESAvailable = GetLoc("FILEMANAGER_SAMPLESAvailable"); // "available"
		public static string FILEMANAGER_nosamples = GetLoc("FILEMANAGER_nosamples"); // "no samples"
		public static string FILEMANAGER_Transmitduration = GetLoc("FILEMANAGER_Transmitduration"); // "Transmit duration :"
		public static string FILEMANAGER_send = GetLoc("FILEMANAGER_send"); // "Flag the file for transmission to <b>DSN</b>"
		public static string FILEMANAGER_Delete = GetLoc("FILEMANAGER_Delete"); // "Delete the file"
		public static string FILEMANAGER_Warning_title = GetLoc("FILEMANAGER_Warning_title"); // "Warning!"
		public static string FILEMANAGER_DeleteConfirm_button1 = GetLoc("FILEMANAGER_DeleteConfirm_button1"); // "Delete it"
		public static string FILEMANAGER_DeleteConfirm_button2 = GetLoc("FILEMANAGER_DeleteConfirm_button2"); // "Keep it"
		public static string FILEMANAGER_analysis = GetLoc("FILEMANAGER_analysis"); // "Flag the file for analysis in a <b>laboratory</b>"
		public static string FILEMANAGER_Dumpsample = GetLoc("FILEMANAGER_Dumpsample"); // "Dump the sample"																
		public static string FILEMANAGER_DumpConfirm_button1 = GetLoc("FILEMANAGER_DumpConfirm_button1"); // "Dump it"
		public static string FILEMANAGER_DumpConfirm_button2 = GetLoc("FILEMANAGER_DumpConfirm_button2"); // "Keep it"

		////////////////////////////////////////////////////////////////////
		// Messages
		////////////////////////////////////////////////////////////////////
		public static string Message_RELAX = GetLoc("Message_RELAX"); // "RELAX"
		public static string Message_WARNING = GetLoc("Message_WARNING"); // "WARNING"
		public static string Message_DANGER = GetLoc("Message_DANGER"); // "DANGER"
		public static string Message_FATALITY = GetLoc("Message_FATALITY"); // "FATALITY"
		public static string Message_BREAKDOWN = GetLoc("Message_BREAKDOWN"); // "BREAKDOWN"

		////////////////////////////////////////////////////////////////////
		// Monitor : main telemetry panel UI
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_TimeoutMsg3 // "New tentative in <<1>> (s)"
		public static string TELEMETRY_title = GetLoc("TELEMETRY_title"); // "TELEMETRY"
		public static string TELEMETRY_EVASUIT = GetLoc("TELEMETRY_EVASUIT"); // "EVA SUIT"
		public static string TELEMETRY_ENVIRONMENT = GetLoc("TELEMETRY_ENVIRONMENT"); // "ENVIRONMENT"
		public static string TELEMETRY_SolarPanelsAverageExposure = GetLoc("TELEMETRY_SolarPanelsAverageExposure"); // "solar panels average exposure"
		public static string TELEMETRY_Exposureignoringbodiesocclusion = GetLoc("TELEMETRY_Exposureignoringbodiesocclusion"); // "Exposure ignoring bodies occlusion"
		public static string TELEMETRY_Exposureignoringbodiesocclusion_desc = GetLoc("TELEMETRY_Exposureignoringbodiesocclusion_desc"); // "Won't change on unloaded vessels\nMake sure to optimize it before switching"
		public static string TELEMETRY_nosensorsinstalled = GetLoc("TELEMETRY_nosensorsinstalled"); // "no sensors installed"
		public static string TELEMETRY_HABITAT = GetLoc("TELEMETRY_HABITAT"); // "HABITAT"
		public static string TELEMETRY_co2level = GetLoc("TELEMETRY_co2level"); // "co2 level"
		public static string TELEMETRY_radiation = GetLoc("TELEMETRY_radiation"); // "radiation"
		public static string TELEMETRY_pressure = GetLoc("TELEMETRY_pressure"); // "pressure"
		public static string TELEMETRY_shielding = GetLoc("TELEMETRY_shielding"); // "shielding"
		public static string TELEMETRY_livingspace = GetLoc("TELEMETRY_livingspace"); // "living space"
		public static string TELEMETRY_comfort = GetLoc("TELEMETRY_comfort"); // "comfort"
		public static string TELEMETRY_EVAsavailable = GetLoc("TELEMETRY_EVAsavailable"); // "EVA's available"
		public static string TELEMETRY_EnvBreathable = GetLoc("TELEMETRY_EnvBreathable"); // "infinite"
		public static string TELEMETRY_Breathableatm = GetLoc("TELEMETRY_Breathableatm"); // "breathable atmosphere"
		public static string TELEMETRY_approx = GetLoc("TELEMETRY_approx"); // "approx (derived from stored N2)"
		public static string TELEMETRY_TRANSMISSION = GetLoc("TELEMETRY_TRANSMISSION"); // "TRANSMISSION"
		public static string TELEMETRY_TRANSMISSION_rate = GetLoc("TELEMETRY_TRANSMISSION_rate"); // "rate"
		public static string TELEMETRY_filetransmitted = GetLoc("TELEMETRY_filetransmitted"); // "file transmitted"
		public static string TELEMETRY_transmitting = GetLoc("TELEMETRY_transmitting"); // "transmitting"
		public static string TELEMETRY_maxtransmissionrate = GetLoc("TELEMETRY_maxtransmissionrate"); // "max transmission rate"
		public static string TELEMETRY_target = GetLoc("TELEMETRY_target"); // "target"
		public static string TELEMETRY_totalsciencetransmitted = GetLoc("TELEMETRY_totalsciencetransmitted"); // "total science transmitted"
		public static string TELEMETRY_SUPPLIES = GetLoc("TELEMETRY_SUPPLIES"); // "SUPPLIES"
		public static string TELEMETRY_nochange = GetLoc("TELEMETRY_nochange"); // "no change"
		public static string TELEMETRY_empty = GetLoc("TELEMETRY_empty"); // "(empty)"
		public static string TELEMETRY_full = GetLoc("TELEMETRY_full"); // "(full)"
		public static string TELEMETRY_VITALS = GetLoc("TELEMETRY_VITALS"); // "VITALS"
		public static string TELEMETRY_HYBERNATED = GetLoc("TELEMETRY_HYBERNATED"); // "HYBERNATED"
		public static string TELEMETRY_GREENHOUSE = GetLoc("TELEMETRY_GREENHOUSE"); // "GREENHOUSE"
		public static string TELEMETRY_readytoharvest = GetLoc("TELEMETRY_readytoharvest"); // "ready to harvest"
		public static string TELEMETRY_growing = GetLoc("TELEMETRY_growing"); // "growing"
		public static string TELEMETRY_timetoharvest = GetLoc("TELEMETRY_timetoharvest"); // "time to harvest"
		public static string TELEMETRY_growth = GetLoc("TELEMETRY_growth"); // "growth"
		public static string TELEMETRY_naturallighting = GetLoc("TELEMETRY_naturallighting"); // "natural lighting"
		public static string TELEMETRY_artificiallighting = GetLoc("TELEMETRY_artificiallighting"); // "artificial lighting"
		public static string TELEMETRY_crop = GetLoc("TELEMETRY_crop"); // "crop"
		public static string TimeoutMsg1 = GetLoc("TimeoutMsg1"); // "Connection in progress"
		public static string TimeoutMsg2 = GetLoc("TimeoutMsg2"); // "Connection timed-out"

		////////////////////////////////////////////////////////////////////
		// Monitor : vessel config UI
		////////////////////////////////////////////////////////////////////
		public static string VESSELCONFIG_title = GetLoc("VESSELCONFIG_title"); // "VESSEL CONFIG"
		public static string VESSELCONFIG_RENDERING = GetLoc("VESSELCONFIG_RENDERING"); // "RENDERING"
		public static string VESSELCONFIG_Highlightfailed = GetLoc("VESSELCONFIG_Highlightfailed"); // "highlight malfunctions"
		public static string VESSELCONFIG_Highlightfailed_desc = GetLoc("VESSELCONFIG_Highlightfailed_desc"); // "Highlight failed components"
		public static string VESSELCONFIG_MESSAGES = GetLoc("VESSELCONFIG_MESSAGES"); // "MESSAGES"
		public static string VESSELCONFIG_EClow = GetLoc("VESSELCONFIG_EClow"); // "Receive a message when\nElectricCharge level is low"
		public static string VESSELCONFIG_battery = GetLoc("VESSELCONFIG_battery"); // "battery"
		public static string VESSELCONFIG_Supplylow = GetLoc("VESSELCONFIG_Supplylow"); // "Receive a message when\nsupply resources level is low"
		public static string VESSELCONFIG_supply = GetLoc("VESSELCONFIG_supply"); // "supply"
		public static string VESSELCONFIG_Signallost = GetLoc("VESSELCONFIG_Signallost"); // "Receive a message when signal is lost or obtained"
		public static string VESSELCONFIG_signal = GetLoc("VESSELCONFIG_signal"); // "signal"
		public static string VESSELCONFIG_Componentfail = GetLoc("VESSELCONFIG_Componentfail"); // "Receive a message\nwhen a component fail"
		public static string VESSELCONFIG_reliability = GetLoc("VESSELCONFIG_reliability"); // "reliability"
		public static string VESSELCONFIG_CMEevent = GetLoc("VESSELCONFIG_CMEevent"); // "Receive a message\nduring CME events"
		public static string VESSELCONFIG_storm = GetLoc("VESSELCONFIG_storm"); // "storm"
		public static string VESSELCONFIG_ScriptExe = GetLoc("VESSELCONFIG_ScriptExe"); // "Receive a message when\nscripts are executed"
		public static string VESSELCONFIG_script = GetLoc("VESSELCONFIG_script"); // "script"

		////////////////////////////////////////////////////////////////////
		// Science Archive Window
		////////////////////////////////////////////////////////////////////
		public static string SCIENCEARCHIVE_title = GetLoc("SCIENCEARCHIVE_title"); // "SCIENCE ARCHIVE"
		public static string SCIENCEARCHIVE_hidearchive = GetLoc("SCIENCEARCHIVE_hidearchive"); // "hide science archive"
		public static string SCIENCEARCHIVE_EXPERIMENTS = GetLoc("SCIENCEARCHIVE_EXPERIMENTS"); // "EXPERIMENTS"
		public static string SCIENCEARCHIVE_filter1 = GetLoc("SCIENCEARCHIVE_filter1"); // "filter by researched"
		public static string SCIENCEARCHIVE_filter2 = GetLoc("SCIENCEARCHIVE_filter2"); // "filter ROCs"
		public static string SCIENCEARCHIVE_filter3 = GetLoc("SCIENCEARCHIVE_filter3"); // "filter by current vessel"
		public static string SCIENCEARCHIVE_EXPERIMENTINFO = GetLoc("SCIENCEARCHIVE_EXPERIMENTINFO"); // "EXPERIMENT INFO"
		public static string SCIENCEARCHIVE_STATUS = GetLoc("SCIENCEARCHIVE_STATUS"); // "STATUS"
		public static string SCIENCEARCHIVE_onvessel = GetLoc("SCIENCEARCHIVE_onvessel"); // "on vessel :"
		public static string SCIENCEARCHIVE_onpart = GetLoc("SCIENCEARCHIVE_onpart"); // "on part :"
		public static string SCIENCEARCHIVE_showarchive = GetLoc("SCIENCEARCHIVE_showarchive"); // "show science archive"
		public static string SCIENCEARCHIVE_showexperimentinfo = GetLoc("SCIENCEARCHIVE_showexperimentinfo"); // "show experiment info"
		public static string SCIENCEARCHIVE_hideexperimentinfo = GetLoc("SCIENCEARCHIVE_hideexperimentinfo"); // "hide experiment info"
		public static string SCIENCEARCHIVE_closebutton = GetLoc("SCIENCEARCHIVE_closebutton"); // "close"
		public static string SCIENCEARCHIVE_forcedrun = GetLoc("SCIENCEARCHIVE_forcedrun"); // "forced run"
		public static string SCIENCEARCHIVE_forcedrun_desc = GetLoc("SCIENCEARCHIVE_forcedrun_desc"); // "force experiment to run even\nif there is no science value left"
		public static string SCIENCEARCHIVE_REQUIREMENTS = GetLoc("SCIENCEARCHIVE_REQUIREMENTS"); // "REQUIREMENTS"
		public static string SCIENCEARCHIVE_state = GetLoc("SCIENCEARCHIVE_state"); // "state"
		public static string SCIENCEARCHIVE_status = GetLoc("SCIENCEARCHIVE_status"); // "status"
		public static string SCIENCEARCHIVE_collected = GetLoc("SCIENCEARCHIVE_collected"); // "collected"
		public static string SCIENCEARCHIVE_samples = GetLoc("SCIENCEARCHIVE_samples"); // "samples"
		public static string SCIENCEARCHIVE_situation = GetLoc("SCIENCEARCHIVE_situation"); // "situation"
		public static string SCIENCEARCHIVE_retrieved = GetLoc("SCIENCEARCHIVE_retrieved"); // "retrieved"
		public static string SCIENCEARCHIVE_invalidsituation = GetLoc("SCIENCEARCHIVE_invalidsituation"); // "invalid situation"
		public static string SCIENCEARCHIVE_value = GetLoc("SCIENCEARCHIVE_value"); // "value"
		public static string SCIENCEARCHIVE_never = GetLoc("SCIENCEARCHIVE_never"); // "never"
		public static string SCIENCEARCHIVE_inRnD = GetLoc("SCIENCEARCHIVE_inRnD"); // "in RnD"
		public static string SCIENCEARCHIVE_inflight = GetLoc("SCIENCEARCHIVE_inflight"); // "in flight)"
		public static string SCIENCEARCHIVE_stop = GetLoc("SCIENCEARCHIVE_stop"); // "stop"
		public static string SCIENCEARCHIVE_start = GetLoc("SCIENCEARCHIVE_start"); // "start"
		public static string SCIENCEARCHIVE_current = GetLoc("SCIENCEARCHIVE_current"); // "current"
		public static string SCIENCEARCHIVE_Showonlyknownsubjects = GetLoc("SCIENCEARCHIVE_Showonlyknownsubjects"); // "Show only known subjects"
		public static string SCIENCEARCHIVE_RnD = GetLoc("SCIENCEARCHIVE_RnD"); // "RnD"
		public static string SCIENCEARCHIVE_RnD_desc = GetLoc("SCIENCEARCHIVE_RnD_desc"); // "Science points\nretrieved in RnD"
		public static string SCIENCEARCHIVE_Flight = GetLoc("SCIENCEARCHIVE_Flight"); // "Flight"
		public static string SCIENCEARCHIVE_Flight_desc = GetLoc("SCIENCEARCHIVE_Flight_desc"); // "Science points\ncollected in all vessels"
		public static string SCIENCEARCHIVE_Value = GetLoc("SCIENCEARCHIVE_Value"); // "Value"
		public static string SCIENCEARCHIVE_Value_desc = GetLoc("SCIENCEARCHIVE_Value_desc"); // "Remaining science value\naccounting for data retrieved in RnD\nand collected in flight"
		public static string SCIENCEARCHIVE_Completed = GetLoc("SCIENCEARCHIVE_Completed"); // "Completed"
		public static string SCIENCEARCHIVE_Completed_desc = GetLoc("SCIENCEARCHIVE_Completed_desc"); // "How many times the subject\nhas been retrieved in RnD"

		////////////////////////////////////////////////////////////////////
		// Module : Emitter
		////////////////////////////////////////////////////////////////////
		public static string Emitter_Action = GetLoc("Emitter_Action"); // "Toggle Active Shield"
		public static string Emitter_EmitIonizing = GetLoc("Emitter_EmitIonizing"); // "Emit ionizing radiation"
		public static string Emitter_ReduceIncoming = GetLoc("Emitter_ReduceIncoming"); // "Reduce incoming radiation"
		public static string Emitter_Emitted = GetLoc("Emitter_Emitted"); // "Radiation emitted"
		public static string Emitter_ActiveShielding = GetLoc("Emitter_ActiveShielding"); // "Active shielding"
		public static string Emitter_none = GetLoc("Emitter_none"); // "none"

		////////////////////////////////////////////////////////////////////
		// Module : Deploy
		////////////////////////////////////////////////////////////////////
		public static string Deploy_actualCost = GetLoc("Deploy_actualCost"); // "EC Usage"
		public static string Deploy_isBroken = GetLoc("Deploy_isBroken"); // "Is broken"

		////////////////////////////////////////////////////////////////////
		// Module : Configure
		////////////////////////////////////////////////////////////////////
		public static string Module_Configure = GetLoc("Module_Configure"); // "Configure"
		public static string Module_Configure_Slots = GetLoc("Module_Configure_Slots"); // "Slots"
		public static string Module_Configure_Reconfigure = GetLoc("Module_Configure_Reconfigure"); // "Reconfigure"
		public static string Module_Configure_Setups = GetLoc("Module_Configure_Setups"); // "Setups:"
		public static string Module_Configurable = GetLoc("Module_Configurable"); // "Configurable"
		public static string Module_Resources = GetLoc("Module_Resources"); // "Resources"
		public static string Module_Extra = GetLoc("Module_Extra"); // "Extra"
		public static string Module_mass = GetLoc("Module_mass"); // "mass"
		public static string Module_cost = GetLoc("Module_cost"); // "cost"

		////////////////////////////////////////////////////////////////////
		// Module : Comfort
		////////////////////////////////////////////////////////////////////
		public static string Module_Comfort = GetLoc("Module_Comfort"); // "Comfort"
		public static string Module_Comfort_Summary1 = GetLoc("Module_Comfort_Summary1"); // "ideal"
		public static string Module_Comfort_Summary2 = GetLoc("Module_Comfort_Summary2"); // "good"
		public static string Module_Comfort_Summary3 = GetLoc("Module_Comfort_Summary3"); // "modest"
		public static string Module_Comfort_Summary4 = GetLoc("Module_Comfort_Summary4"); // "poor"
		public static string Module_Comfort_Summary5 = GetLoc("Module_Comfort_Summary5"); // "none"

		////////////////////////////////////////////////////////////////////
		// Module : Experiment
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Module_Experiment_issue12 // "missing <<1>>" // missing [Resource Name]
		// #KERBALISM_Module_Experiment_MultipleRunsMessage // "Can't start <<1>> a second time on vessel <<2>>"
		public static string Module_Experiment_Prepare = GetLoc("Module_Experiment_Prepare"); // "Prepare"
		public static string Module_Experiment_Reset = GetLoc("Module_Experiment_Reset"); // "Reset"
		public static string Module_Experiment_issue_title = GetLoc("Module_Experiment_issue_title"); // "issue"
		public static string Module_Experiment_issue1 = GetLoc("Module_Experiment_issue1"); // "invalid situation"
		public static string Module_Experiment_issue2 = GetLoc("Module_Experiment_issue2"); // "shrouded"
		public static string Module_Experiment_issue3 = GetLoc("Module_Experiment_issue3"); // "reset required"
		public static string Module_Experiment_issue4 = GetLoc("Module_Experiment_issue4"); // "no Electricity"
		public static string Module_Experiment_issue5 = GetLoc("Module_Experiment_issue5"); // "crew on board"
		public static string Module_Experiment_issue6 = GetLoc("Module_Experiment_issue6"); // "depleted"
		public static string Module_Experiment_issue7 = GetLoc("Module_Experiment_issue7"); // "not prepared"
		public static string Module_Experiment_issue8 = GetLoc("Module_Experiment_issue8"); // "background flight"
		public static string Module_Experiment_issue9 = GetLoc("Module_Experiment_issue9"); // "unmet requirement"
		public static string Module_Experiment_issue10 = GetLoc("Module_Experiment_issue10"); // "missing resource"
		public static string Module_Experiment_issue11 = GetLoc("Module_Experiment_issue11"); // "no storage space"
		public static string Module_Experiment_runningstate1 = GetLoc("Module_Experiment_runningstate1"); // "stopped"
		public static string Module_Experiment_runningstate2 = GetLoc("Module_Experiment_runningstate2"); // "started"
		public static string Module_Experiment_runningstate3 = GetLoc("Module_Experiment_runningstate3"); // "forced run"
		public static string Module_Experiment_runningstate4 = GetLoc("Module_Experiment_runningstate4"); // "broken"
		public static string Module_Experiment_runningstate5 = GetLoc("Module_Experiment_runningstate5"); // "running"
		public static string Module_Experiment_runningstate6 = GetLoc("Module_Experiment_runningstate6"); // "waiting"
		public static string Module_Experiment_ScienceValuenone = GetLoc("Module_Experiment_ScienceValuenone"); // "none"
		public static string Module_Experiment_Requires = GetLoc("Module_Experiment_Requires"); // "Requires:"
		public static string Module_Experiment_Specifics_info1 = GetLoc("Module_Experiment_Specifics_info1"); // "Data size"
		public static string Module_Experiment_Specifics_info2 = GetLoc("Module_Experiment_Specifics_info2"); // "Data rate"
		public static string Module_Experiment_Specifics_info3 = GetLoc("Module_Experiment_Specifics_info3"); // "Duration"
		public static string Module_Experiment_Specifics_info4 = GetLoc("Module_Experiment_Specifics_info4"); // "Sample size"
		public static string Module_Experiment_Specifics_info5 = GetLoc("Module_Experiment_Specifics_info5"); // "Sample mass"
		public static string Module_Experiment_Specifics_info6 = GetLoc("Module_Experiment_Specifics_info6"); // "Samples"
		public static string Module_Experiment_Specifics_info7_sample = GetLoc("Module_Experiment_Specifics_info7_sample"); // "Duration"
		public static string Module_Experiment_Specifics_Situations = GetLoc("Module_Experiment_Specifics_Situations"); // "Situations:"
		public static string Module_Experiment_Specifics_info8 = GetLoc("Module_Experiment_Specifics_info8"); // "Needs:"
		public static string Module_Experiment_Specifics_info9 = GetLoc("Module_Experiment_Specifics_info9"); // "EC"
		public static string Module_Experiment_Specifics_info10 = GetLoc("Module_Experiment_Specifics_info10"); // "Preparation"
		public static string Module_Experiment_Specifics_info10_none = GetLoc("Module_Experiment_Specifics_info10_none"); // "none"
		public static string Module_Experiment_Specifics_info11 = GetLoc("Module_Experiment_Specifics_info11"); // "Operation"
		public static string Module_Experiment_Specifics_info11_unmanned = GetLoc("Module_Experiment_Specifics_info11_unmanned"); // "unmanned"
		public static string Module_Experiment_Specifics_info12 = GetLoc("Module_Experiment_Specifics_info12"); // "Reset"
		public static string Module_Experiment_Specifics_info12_none = GetLoc("Module_Experiment_Specifics_info12_none"); // "none"
		public static string Module_Experiment_MultipleRunsMessage_title = GetLoc("Module_Experiment_MultipleRunsMessage_title"); // "ALREADY RUNNING"																														
		public static string Module_Experiment_Message1 = GetLoc("Module_Experiment_Message1"); // "I'm not qualified for this"
		public static string Module_Experiment_Message2 = GetLoc("Module_Experiment_Message2"); // "I will not even know where to start"
		public static string Module_Experiment_Message3 = GetLoc("Module_Experiment_Message3"); // "I'm afraid I can't do that"
		public static string Module_Experiment_Message4 = GetLoc("Module_Experiment_Message4"); // "Preparation Complete"
		public static string Module_Experiment_Message5 = GetLoc("Module_Experiment_Message5"); // "Ready to go"
		public static string Module_Experiment_Message6 = GetLoc("Module_Experiment_Message6"); // "Let's start doing some science!"
		public static string Module_Experiment_Message7 = GetLoc("Module_Experiment_Message7"); // "Reset Done"
		public static string Module_Experiment_Message8 = GetLoc("Module_Experiment_Message8"); // "It's good to go again"
		public static string Module_Experiment_Message9 = GetLoc("Module_Experiment_Message9"); // "Ready for the next bit of science"

		////////////////////////////////////////////////////////////////////
		// Module : Greenhouse
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Greenhouse_msg_1 // "On <<1>> "
		// #KERBALISM_Greenhouse_msg_2 // "harvest produced <<1>>"
		// #KERBALISM_Greenhouse_msg_3 // "emergency harvest produced <<1>>"
		// #KERBALISM_Greenhouse_resoucesmissing // "missing <<1>>"
		public static string Greenhouse = GetLoc("Greenhouse"); // "Greenhouse"
		public static string Greenhouse_Action = GetLoc("Greenhouse_Action"); // "Enable/Disable Greenhouse"
		public static string Greenhouse_EmergencyHarvest = GetLoc("Greenhouse_EmergencyHarvest"); // "Emergency Harvest"
		public static string Greenhouse_Harvest = GetLoc("Greenhouse_Harvest"); // "Harvest"
		public static string Greenhouse_status_artificial = GetLoc("Greenhouse_status_artificial"); // "Artificial lighting"
		public static string Greenhouse_status_natural = GetLoc("Greenhouse_status_natural"); // "Natural lighting"
		public static string Greenhouse_status_tta = GetLoc("Greenhouse_status_tta"); // "Time to harvest"
		public static string Greenhouse_Greenhouse = GetLoc("Greenhouse_Greenhouse"); // "Greenhouse"
		public static string Greenhouse_desc = GetLoc("Greenhouse_desc"); // "Grow crops in space and on the surface of celestial bodies, even far from the sun."
		public static string Greenhouse_disabled = GetLoc("Greenhouse_disabled"); // "disabled"
		public static string Greenhouse_enabled = GetLoc("Greenhouse_enabled"); // "enabled"																	
		public static string Greenhouse_issue1 = GetLoc("Greenhouse_issue1"); // "insufficient lighting"
		public static string Greenhouse_issue2 = GetLoc("Greenhouse_issue2"); // "insufficient pressure"
		public static string Greenhouse_issue3 = GetLoc("Greenhouse_issue3"); // "excessive radiation"
		public static string Greenhouse_info1 = GetLoc("Greenhouse_info1"); // "Harvest size"
		public static string Greenhouse_info2 = GetLoc("Greenhouse_info2"); // "Harvest time"
		public static string Greenhouse_info3 = GetLoc("Greenhouse_info3"); // "Lighting tolerance"
		public static string Greenhouse_info4 = GetLoc("Greenhouse_info4"); // "Pressure tolerance"
		public static string Greenhouse_info5 = GetLoc("Greenhouse_info5"); // "Radiation tolerance"
		public static string Greenhouse_info6 = GetLoc("Greenhouse_info6"); // "Lamps EC rate"
		public static string Greenhouse_info7 = GetLoc("Greenhouse_info7"); // "Required resources"
		public static string Greenhouse_CarbonDioxide = GetLoc("Greenhouse_CarbonDioxide"); // "CarbonDioxide"
		public static string Greenhouse_CarbonDioxide_desc = GetLoc("Greenhouse_CarbonDioxide_desc"); // "Crops can also use the CO2 in the atmosphere without a scrubber."
		public static string Greenhouse_Byproducts = GetLoc("Greenhouse_Byproducts"); // "By-products"

		////////////////////////////////////////////////////////////////////
		// Module : Habitat
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Habitat_postmsg "Can't disable <b><<1>> habitat</b> while crew is inside"
		public static string Habitat = GetLoc("Habitat"); // "Habitat"
		public static string Habitat_Action = GetLoc("Habitat_Action"); // "Enable/Disable Habitat"
		public static string Habitat_Surface = GetLoc("Habitat_Surface"); // "Surface"
		public static string Habitat_Volume = GetLoc("Habitat_Volume"); // "Volume"
		public static string Habitat_pressurizing = GetLoc("Habitat_pressurizing"); // "pressurizing..."
		public static string Habitat_depressurizing = GetLoc("Habitat_depressurizing"); // "depressurizing..."
		public static string Habitat_inflating = GetLoc("Habitat_inflating"); // "inflating..."
		public static string Habitat_deflating = GetLoc("Habitat_deflating"); // "deflating..."
		public static string Habitat_info1 = GetLoc("Habitat_info1"); // "Volume"
		public static string Habitat_info2 = GetLoc("Habitat_info2"); // "Surface"
		public static string Habitat_info3 = GetLoc("Habitat_info3"); // "Pressurized"
		public static string Habitat_yes = GetLoc("Habitat_yes"); // "yes"
		public static string Habitat_no = GetLoc("Habitat_no"); // "no"
		public static string Habitat_none = GetLoc("Habitat_none"); // "none"
		public static string Habitat_info4 = GetLoc("Habitat_info4"); // "Inflatable"
		public static string Habitat_info5 = GetLoc("Habitat_info5"); // "Added mass per crew"
		public static string Habitat_Summary1 = GetLoc("Habitat_Summary1"); // "ideal"
		public static string Habitat_Summary2 = GetLoc("Habitat_Summary2"); // "good"
		public static string Habitat_Summary3 = GetLoc("Habitat_Summary3"); // "modest"
		public static string Habitat_Summary4 = GetLoc("Habitat_Summary4"); // "poor"
		public static string Habitat_Summary5 = GetLoc("Habitat_Summary5"); // "cramped"

		////////////////////////////////////////////////////////////////////
		// Module : HardDrive
		////////////////////////////////////////////////////////////////////
		public static string HardDrive = GetLoc("HardDrive"); // "Hard Drive"
		public static string HardDrive_StoreData = GetLoc("HardDrive_StoreData"); // "Store data"
		public static string HardDrive_TakeData = GetLoc("HardDrive_TakeData"); // "Take data"
		public static string HardDrive_TransferData = GetLoc("HardDrive_TransferData"); // "Transfer data here"
		public static string HardDrive_DataCapacity = GetLoc("HardDrive_DataCapacity"); // "Data Capacity"
		public static string HardDrive_SampleCapacity = GetLoc("HardDrive_SampleCapacity"); // "Sample Capacity"
		public static string HardDrive_Capacity = GetLoc("HardDrive_Capacity"); // "Capacity"
		public static string HardDrive_Data = GetLoc("HardDrive_Data"); // "Data"
		public static string HardDrive_Dataempty = GetLoc("HardDrive_Dataempty"); // "empty"
		public static string HardDrive_WARNING_title = GetLoc("HardDrive_WARNING_title"); // "WARNING: not evering copied"
		public static string HardDrive_WARNING = GetLoc("HardDrive_WARNING"); // "Storage is at capacity"
		public static string HardDrive_info1 = GetLoc("HardDrive_info1"); // "File capacity"
		public static string HardDrive_info2 = GetLoc("HardDrive_info2"); // "Sample capacity"
		public static string HardDrive_Capacityunlimited = GetLoc("HardDrive_Capacityunlimited"); // "unlimited"

		////////////////////////////////////////////////////////////////////
		// Module : GravityRing
		////////////////////////////////////////////////////////////////////
		public static string GravityRing_Action = GetLoc("GravityRing_Action"); // "Deploy/Retract Ring"
		public static string GravityRing_Toggle = GetLoc("GravityRing_Toggle"); // "Deploy"
		public static string GravityRing_yes = GetLoc("GravityRing_yes"); // "yes"
		public static string GravityRing_no = GetLoc("GravityRing_no"); // "no"
		public static string GravityRing_info1 = GetLoc("GravityRing_info1"); // "bonus"
		public static string GravityRing_info2 = GetLoc("GravityRing_info2"); // "deployable"

		////////////////////////////////////////////////////////////////////
		// Module : Harvester
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Harvester_generatedescription // "Extract <<1>> from <<2>>"
		public static string Harvester_Action = GetLoc("Harvester_Action"); // "Start/Stop Harvester"
		public static string Harvester_running = GetLoc("Harvester_running"); // "running"
		public static string Harvester_stopped = GetLoc("Harvester_stopped"); // "stopped"
		public static string Harvester_none = GetLoc("Harvester_none"); // "none"
		public static string Harvester_land_valid = GetLoc("Harvester_land_valid"); // "no ground contact"
		public static string Harvester_ocean_valid = GetLoc("Harvester_ocean_valid"); // "not in ocean"
		public static string Harvester_atmo_valid = GetLoc("Harvester_atmo_valid"); // "not in atmosphere"
		public static string Harvester_space_valid = GetLoc("Harvester_space_valid"); // "not in space"
		public static string Harvester_pressurebelow = GetLoc("Harvester_pressurebelow"); // "pressure below threshold"
		public static string Harvester_abundancebelow = GetLoc("Harvester_abundancebelow"); // "abundance below threshold"																				
		public static string Harvester_source1 = GetLoc("Harvester_source1"); // "the surface"
		public static string Harvester_source2 = GetLoc("Harvester_source2"); // "the ocean"
		public static string Harvester_source3 = GetLoc("Harvester_source3"); // "the atmosphere"
		public static string Harvester_source4 = GetLoc("Harvester_source4"); // "space"
		public static string Harvester_info1 = GetLoc("Harvester_info1"); // "type"
		public static string Harvester_info2 = GetLoc("Harvester_info2"); // "resource"
		public static string Harvester_info3 = GetLoc("Harvester_info3"); // "min abundance"
		public static string Harvester_info4 = GetLoc("Harvester_info4"); // "min pressure"
		public static string Harvester_info5 = GetLoc("Harvester_info5"); // "extraction rate"
		public static string Harvester_info6 = GetLoc("Harvester_info6"); // "at abundance"
		public static string Harvester_info7 = GetLoc("Harvester_info7"); // "ec consumption"

		////////////////////////////////////////////////////////////////////
		// Module : ScanSat
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Scansat_Scannerhalted_text // "Scanner halted on <<1>>. No storage left on vessel."
		// #KERBALISM_Scansat_sensorresumed // "SCANsat sensor resumed operations on <<1>>"
		// #KERBALISM_Scansat_sensordisabled // "SCANsat sensor was disabled on <<1>>"
		public static string Scansat_Scannerhalted = GetLoc("Scansat_Scannerhalted"); // "Scanner halted"

		////////////////////////////////////////////////////////////////////
		// Module : Laboratory
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Laboratory_Analyzed // "Our laboratory on <<1>> analyzed <<2>>"
		public static string Laboratory_Title = GetLoc("Laboratory_Title"); // "Laboratory"
		public static string Laboratory_Toggle = GetLoc("Laboratory_Toggle"); // "Toggle Lab"
		public static string Laboratory_Clean = GetLoc("Laboratory_Clean"); // "Clean Lab"
		public static string Laboratory_stopped = GetLoc("Laboratory_stopped"); // "stopped"
		public static string Laboratory_Notspace = GetLoc("Laboratory_Notspace"); // "Not enough space on hard drive"
		public static string Laboratory_Action = GetLoc("Laboratory_Action"); // "Enable/Disable Lab"
		public static string Laboratory_NoEC = GetLoc("Laboratory_NoEC"); // "no electric charge"
		public static string Laboratory_NoSample = GetLoc("Laboratory_NoSample"); // "no samples to analyze"
		public static string Laboratory_Cleaned = GetLoc("Laboratory_Cleaned"); // "Vessel experiments have been cleaned."
		public static string Laboratory_Specs = GetLoc("Laboratory_Specs"); // "Analyze samples to produce transmissible data"
		public static string Laboratory_Researcher = GetLoc("Laboratory_Researcher"); // "Researcher"
		public static string Laboratory_CanClean = GetLoc("Laboratory_CanClean"); // "Can clean experiments"
		public static string Laboratory_ECrate = GetLoc("Laboratory_ECrate"); // "EC rate"
		public static string Laboratory_rate = GetLoc("Laboratory_rate"); // "Analysis rate"
		public static string Laboratory_Analysis = GetLoc("Laboratory_Analysis"); // "ANALYSIS COMPLETED"
		public static string Laboratory_Results = GetLoc("Laboratory_Results"); // "The results can be transmitted now"
		public static string Laboratory_Nostorage = GetLoc("Laboratory_Nostorage"); // "No storage available"

		////////////////////////////////////////////////////////////////////
		// Module : PassiveShield
		////////////////////////////////////////////////////////////////////
		public static string PassiveShield_Sandbags = GetLoc("PassiveShield_Sandbags"); // "Sandbags"
		public static string PassiveShield_fill = GetLoc("PassiveShield_fill"); // "fill"
		public static string PassiveShield_empty = GetLoc("PassiveShield_empty"); // "empty"
		public static string PassiveShield_stowed = GetLoc("PassiveShield_stowed"); // "stowed"
		public static string PassiveShield_absorbing = GetLoc("PassiveShield_absorbing"); // "absorbing"
		public static string PassiveShield_MessagePost = GetLoc("PassiveShield_MessagePost"); // "I don't know how this works!"

		////////////////////////////////////////////////////////////////////
		// Module : PlannerController
		////////////////////////////////////////////////////////////////////
		public static string PlannerController_yes = GetLoc("PlannerController_yes"); // "yes"
		public static string PlannerController_no = GetLoc("PlannerController_no"); // "no"

		////////////////////////////////////////////////////////////////////
		// Module : ProcessController
		////////////////////////////////////////////////////////////////////
		public static string ProcessController_Start_Stop = GetLoc("ProcessController_Start_Stop"); // "Start/Stop"
		public static string ProcessController_broken = GetLoc("ProcessController_broken"); // "broken"
		public static string ProcessController_running = GetLoc("ProcessController_running"); // "running"
		public static string ProcessController_stopped = GetLoc("ProcessController_stopped"); // "stopped"
		public static string ProcessController_Dump = GetLoc("ProcessController_Dump"); // "Dump"
		public static string ProcessController_info1 = GetLoc("ProcessController_info1"); // "Half-life"

		////////////////////////////////////////////////////////////////////
		// Module : Reliability
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Reliability_Inspect // "Inspect <<1>>"
		// #KERBALISM_Reliability_Repair // "Repair <<1>>"
		// #KERBALISM_Reliability_Service // "Service <<1>>"
		// #KERBALISM_Reliability_qualityinfo // "<<1>> quality"
		// #KERBALISM_Reliability_MessagePost14 // "<<1>> repaired"
		// #KERBALISM_Reliability_MessagePost19 // "<<1>> serviced"
		// #KERBALISM_Reliability_MessagePost24 // "<<1>> malfunctioned on <<2>>"
		// #KERBALISM_Reliability_MessagePost26 // "<<1>> failed on <<2>>"
		// #KERBALISM_Reliability_MessagePost28 // "There has been a problem with <<1>> on <<2>>"
		public static string Reliability_Reliability = GetLoc("Reliability_Reliability"); // "Reliability"
		public static string Reliability_criticalfailure = GetLoc("Reliability_criticalfailure"); // "critical failure"
		public static string Reliability_malfunction = GetLoc("Reliability_malfunction"); // "malfunction"
		public static string Reliability_burnremaining = GetLoc("Reliability_burnremaining"); // "remaining burn:"
		public static string Reliability_ignitions = GetLoc("Reliability_ignitions"); // "ignitions:"
		public static string Reliability_takingradiationdamage = GetLoc("Reliability_takingradiationdamage"); // "taking radiation damage"
		public static string Reliability_qualityhigh = GetLoc("Reliability_qualityhigh"); // "high"
		public static string Reliability_qualitystandard = GetLoc("Reliability_qualitystandard"); // "standard"
		public static string Reliability_MTBF = GetLoc("Reliability_MTBF"); // "MTBF:                //Mean Time Between Failures(I guess)"
		public static string Reliability_Burntime = GetLoc("Reliability_Burntime"); // "Burn time:"
		public static string Reliability_MessagePost1 = GetLoc("Reliability_MessagePost1"); // "It is practically new"
		public static string Reliability_MessagePost2 = GetLoc("Reliability_MessagePost2"); // "It is in good shape"
		public static string Reliability_MessagePost3 = GetLoc("Reliability_MessagePost3"); // "This will last for ages"
		public static string Reliability_MessagePost4 = GetLoc("Reliability_MessagePost4"); // "Brand new!"
		public static string Reliability_MessagePost5 = GetLoc("Reliability_MessagePost5"); // "Doesn't look used. Is this even turned on?"
		public static string Reliability_MessagePost6 = GetLoc("Reliability_MessagePost6"); // "Looks like it's going to fall off soon."
		public static string Reliability_MessagePost7 = GetLoc("Reliability_MessagePost7"); // "Better get the duck tape ready!"
		public static string Reliability_MessagePost8 = GetLoc("Reliability_MessagePost8"); // "It is reaching its operational limits."
		public static string Reliability_MessagePost9 = GetLoc("Reliability_MessagePost9"); // "How is this still working?"
		public static string Reliability_MessagePost10 = GetLoc("Reliability_MessagePost10"); // "It could fail at any moment now."
		public static string Reliability_MessagePost11 = GetLoc("Reliability_MessagePost11"); // "I'm not qualified for this"
		public static string Reliability_MessagePost12 = GetLoc("Reliability_MessagePost12"); // "I will not even know where to start"
		public static string Reliability_MessagePost13 = GetLoc("Reliability_MessagePost13"); // "I'm afraid I can't do that"
		public static string Reliability_MessagePost15 = GetLoc("Reliability_MessagePost15"); // "A powerkick did the trick."
		public static string Reliability_MessagePost16 = GetLoc("Reliability_MessagePost16"); // "Duct tape, is there something it can't fix?"
		public static string Reliability_MessagePost17 = GetLoc("Reliability_MessagePost17"); // "Fully operational again."
		public static string Reliability_MessagePost18 = GetLoc("Reliability_MessagePost18"); // "We are back in business."
		public static string Reliability_MessagePost20 = GetLoc("Reliability_MessagePost20"); // "I don't know how this was still working."
		public static string Reliability_MessagePost21 = GetLoc("Reliability_MessagePost21"); // "Fastened that loose screw."
		public static string Reliability_MessagePost22 = GetLoc("Reliability_MessagePost22"); // "Someone forgot a toothpick in there."
		public static string Reliability_MessagePost23 = GetLoc("Reliability_MessagePost23"); // "As good as new!"
		public static string Reliability_MessagePost25 = GetLoc("Reliability_MessagePost25"); // "We can still repair it"
		public static string Reliability_MessagePost27 = GetLoc("Reliability_MessagePost27"); // "It is gone for good"
		public static string Reliability_MessagePost29 = GetLoc("Reliability_MessagePost29"); // "We were able to fix it remotely, this time"
		public static string Reliability_info1 = GetLoc("Reliability_info1"); // "Redundancy"
		public static string Reliability_info2 = GetLoc("Reliability_info2"); // "Repair"
		public static string Reliability_info3 = GetLoc("Reliability_info3"); // "Standard quality"
		public static string Reliability_info4 = GetLoc("Reliability_info4"); // "MTBF"
		public static string Reliability_info5 = GetLoc("Reliability_info5"); // "Ignition failures"
		public static string Reliability_info6 = GetLoc("Reliability_info6"); // "Rated burn duration"
		public static string Reliability_info7 = GetLoc("Reliability_info7"); // "Rated ignitions"
		public static string Reliability_info8 = GetLoc("Reliability_info8"); // "Radiation rating"
		public static string Reliability_info9 = GetLoc("Reliability_info9"); // "High quality"
		public static string Reliability_info10 = GetLoc("Reliability_info10"); // "Extra cost"
		public static string Reliability_info11 = GetLoc("Reliability_info11"); // "Extra mass"

		////////////////////////////////////////////////////////////////////
		// Module : Sensor
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Sensor_insideatmosphere // "inside <b>atmosphere</b>(<<1>>)"
		public static string Sensor_info = GetLoc("Sensor_info"); // "Add telemetry readings to the part ui, and to the telemetry panel"
		public static string Sensor_Type = GetLoc("Sensor_Type"); // "Type"
		public static string Sensor_shorttextinfo1 = GetLoc("Sensor_shorttextinfo1"); // "nothing here"
		public static string Sensor_shorttextinfo2 = GetLoc("Sensor_shorttextinfo2"); // "almost one"
		public static string Sensor_shorttextinfo3 = GetLoc("Sensor_shorttextinfo3"); // "WOW!"
		public static string Sensor_solarflux = GetLoc("Sensor_solarflux"); // "solar flux"
		public static string Sensor_albedoflux = GetLoc("Sensor_albedoflux"); // "albedo flux"
		public static string Sensor_bodyflux = GetLoc("Sensor_bodyflux"); // "body flux"
		public static string Sensor_environment = GetLoc("Sensor_environment"); // "environment"
		public static string Sensor_habitats = GetLoc("Sensor_habitats"); // "habitats"
		public static string Sensor_insideocean = GetLoc("Sensor_insideocean"); // "inside <b>ocean</b>"
		public static string Sensor_breathable = GetLoc("Sensor_breathable"); // "breathable"
		public static string Sensor_notbreathable = GetLoc("Sensor_notbreathable"); // "not breathable"
		public static string Sensor_insidethermosphere = GetLoc("Sensor_insidethermosphere"); // "inside <b>thermosphere</b>"
		public static string Sensor_insideexosphere = GetLoc("Sensor_insideexosphere"); // "inside <b>exosphere</b>"
		public static string Sensor_Graviolidetection = GetLoc("Sensor_Graviolidetection"); // "Gravioli detection events per-year: "
		public static string Sensor_info1 = GetLoc("Sensor_info1"); // "The elusive negative gravioli particle\nseems to be much harder to detect than expected."
		public static string Sensor_info2 = GetLoc("Sensor_info2"); // "On the other\nhand there seems to be plenty\nof useless positive graviolis around."

		////////////////////////////////////////////////////////////////////
		// Module : Sickbay
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Sickbay_cureEverybody // "<<1>>: dismiss <<2>>" //<<2>> -> patientName
		// #KERBALISM_Sickbay_cureEverybody2 // "<<1>>: cure <<2>>"
		// #KERBALISM_Sickbay_info4 // "<<1>> Kerbals"
		public static string Sickbay_cure = GetLoc("Sickbay_cure"); // "cure"
		public static string Sickbay_Start_Stop = GetLoc("Sickbay_Start_Stop"); // "Start/Stop"
		public static string Sickbay_running = GetLoc("Sickbay_running"); // "running"
		public static string Sickbay_stopped = GetLoc("Sickbay_stopped"); // "stopped"
		public static string Sickbay_info1 = GetLoc("Sickbay_info1"); // "Cures"
		public static string Sickbay_info2 = GetLoc("Sickbay_info2"); // "All kerbals in part"
		public static string Sickbay_info3 = GetLoc("Sickbay_info3"); // "Capacity"

		////////////////////////////////////////////////////////////////////
		// Module : SolarPanelFixer
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_SolarPanelFixer_occludedby // "occluded by <<1>>"
		public static string SolarPanelFixer_Solarpanel = GetLoc("SolarPanelFixer_Solarpanel"); // "Solar panel"
		public static string SolarPanelFixer_Solarpaneloutput = GetLoc("SolarPanelFixer_Solarpaneloutput"); // "Solar panel output"
		public static string SolarPanelFixer_simulated = GetLoc("SolarPanelFixer_simulated"); // "<color=#00ff00>simulated</color>"
		public static string SolarPanelFixer_ignored = GetLoc("SolarPanelFixer_ignored"); // "<color=#ffff00>ignored</color>"
		public static string SolarPanelFixer_inshadow = GetLoc("SolarPanelFixer_inshadow"); // "in shadow"
		public static string SolarPanelFixer_occludedbyterrain = GetLoc("SolarPanelFixer_occludedbyterrain"); // "occluded by terrain"
		public static string SolarPanelFixer_badorientation = GetLoc("SolarPanelFixer_badorientation"); // "bad orientation"
		public static string SolarPanelFixer_analytic = GetLoc("SolarPanelFixer_analytic"); // "analytic"
		public static string SolarPanelFixer_exposure = GetLoc("SolarPanelFixer_exposure"); // "exposure"
		public static string SolarPanelFixer_wear = GetLoc("SolarPanelFixer_wear"); // "wear"
		public static string SolarPanelFixer_Selecttrackedstar = GetLoc("SolarPanelFixer_Selecttrackedstar"); // "Select tracked star"
		public static string SolarPanelFixer_SelectTrackingBody = GetLoc("SolarPanelFixer_SelectTrackingBody"); // "SelectTrackingBody"
		public static string SolarPanelFixer_SelectTrackedstar_msg = GetLoc("SolarPanelFixer_SelectTrackedstar_msg"); // "Select the star you want to track with this solar panel."
		public static string SolarPanelFixer_Automatic = GetLoc("SolarPanelFixer_Automatic"); // "Automatic"
		public static string SolarPanelFixer_retracted = GetLoc("SolarPanelFixer_retracted"); // "retracted"
		public static string SolarPanelFixer_extending = GetLoc("SolarPanelFixer_extending"); // "extending"
		public static string SolarPanelFixer_retracting = GetLoc("SolarPanelFixer_retracting"); // "retracting"
		public static string SolarPanelFixer_broken = GetLoc("SolarPanelFixer_broken"); // "broken"
		public static string SolarPanelFixer_failure = GetLoc("SolarPanelFixer_failure"); // "failure"
		public static string SolarPanelFixer_invalidstate = GetLoc("SolarPanelFixer_invalidstate"); // "invalid state"
		public static string SolarPanelFixer_Trackedstar = GetLoc("SolarPanelFixer_Trackedstar"); // "Tracked star"
		public static string SolarPanelFixer_AutoTrack = GetLoc("SolarPanelFixer_AutoTrack"); // "[Auto] : "



		////////////////////////////////////////////////////////////////////
		// Class : Callbacks
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_CallBackMsg_EvaNoMP // "There isn't any <<1>> in the EVA suit"
		public static string CallBackMsg_EvaNoMP2 = GetLoc("CallBackMsg_EvaNoMP2"); // "Don't let the ladder go!"
		public static string CallBackMsg_PROGRESS = GetLoc("CallBackMsg_PROGRESS"); // "PROGRESS"
		public static string CallBackMsg_PROGRESS2 = GetLoc("CallBackMsg_PROGRESS2"); // "Our scientists just made a breakthrough"

		////////////////////////////////////////////////////////////////////
		// Class : Preferences
		////////////////////////////////////////////////////////////////////
		public static string Preferences_Reliability = GetLoc("Preferences_Reliability"); // "Reliability"
		public static string HighlightMalfunctions = GetLoc("HighlightMalfunctions"); // "Highlight Malfunctions"
		public static string HighlightMalfunctions_desc = GetLoc("HighlightMalfunctions_desc"); // "Highlight faild parts in flight"
		public static string PartMalfunctions = GetLoc("PartMalfunctions"); // "Part Malfunctions"
		public static string PartMalfunctions_desc = GetLoc("PartMalfunctions_desc"); // "Allow engine failures based on part age and mean time between failures"
		public static string CriticalFailureRate = GetLoc("CriticalFailureRate"); // "Critical Failure Rate"
		public static string CriticalFailureRate_desc = GetLoc("CriticalFailureRate_desc"); // "Proportion of malfunctions that lead to critical failures"
		public static string FixableFailureRate = GetLoc("FixableFailureRate"); // "Fixable Failure Rate"
		public static string FixableFailureRate_desc = GetLoc("FixableFailureRate_desc"); // "Proportion of malfunctions that can be fixed remotely"
		public static string IncentiveRedundancy = GetLoc("IncentiveRedundancy"); // "Incentive Redundancy"
		public static string IncentiveRedundancy_desc = GetLoc("IncentiveRedundancy_desc"); // "Each malfunction will increase the MTBF\nof components in the same redundancy group"
		public static string EngineMalfunctions = GetLoc("EngineMalfunctions"); // "Engine Malfunctions"
		public static string EngineMalfunctions_desc = GetLoc("EngineMalfunctions_desc"); // "Allow engine failures on ignition and exceeded burn durations"
		public static string EngineIgnitionFailureChance = GetLoc("EngineIgnitionFailureChance"); // "Engine Ignition Failure Chance"
		public static string EngineIgnitionFailureChance_desc = GetLoc("EngineIgnitionFailureChance_desc"); // "Adjust the probability of engine failures on ignition"
		public static string EngineBurnFailureChance = GetLoc("EngineBurnFailureChance"); // "Engine Burn Failure Chance"
		public static string EngineBurnFailureChance_desc = GetLoc("EngineBurnFailureChance_desc"); // "Adjust the probability of an engine failure caused by excessive burn time"

		//
		public static string Preferences_Science = GetLoc("Preferences_Science"); // "Science"
		public static string TransmitScienceImmediately = GetLoc("TransmitScienceImmediately"); // "Transmit Science Immediately"
		public static string TransmitScienceImmediately_desc = GetLoc("TransmitScienceImmediately_desc"); // "Automatically flag science files for transmission"
		public static string AnalyzeSamplesImmediately = GetLoc("AnalyzeSamplesImmediately"); // "Analyze Samples Immediately"
		public static string AnalyzeSamplesImmediately_desc = GetLoc("AnalyzeSamplesImmediately_desc"); // "Automatically flag samples for analysis in a lab"
		public static string AntennaSpeed = GetLoc("AntennaSpeed"); // "Antenna Speed"
		public static string AntennaSpeed_desc = GetLoc("AntennaSpeed_desc"); // "Antenna Bandwidth factor"
		public static string Alwaysallowsampletransfers = GetLoc("Alwaysallowsampletransfers"); // "Always allow sample transfers"
		public static string Alwaysallowsampletransfers_desc = GetLoc("Alwaysallowsampletransfers_desc"); // "When off, sample transfer is only available in crewed vessels"

		//
		public static string Preferences_Notifications = GetLoc("Preferences_Notifications"); // "Notifications"
		public static string ElectricalCharge = GetLoc("ElectricalCharge"); // "Electrical Charge"
		public static string ElectricalCharge_desc = GetLoc("ElectricalCharge_desc"); // "Show a message when EC level is low\n(Preset, can be changed per vessel)"
		public static string Supplies = GetLoc("Supplies"); // "Supplies"
		public static string Supplies_desc = GetLoc("Supplies_desc"); // "Show a message when supply resources level is low\n(Preset, can be changed per vessel)"
		public static string Signal = GetLoc("Signal"); // "Signal"
		public static string Signal_desc = GetLoc("Signal_desc"); // "Show a message when signal is lost or obtained\n(Preset, can be changed per vessel)"
		public static string Failures = GetLoc("Failures"); // "Failures"
		public static string Failures_desc = GetLoc("Failures_desc"); // "Show a message when a components fail\n(Preset, can be changed per vessel)"
		public static string SpaceWeather = GetLoc("SpaceWeather"); // "Space Weather"
		public static string SpaceWeather_desc = GetLoc("SpaceWeather_desc"); // "Show a message for CME events\n(Preset, can be changed per vessel)"
		public static string Scripts = GetLoc("Scripts"); // "Scripts"
		public static string Scripts_desc = GetLoc("Scripts_desc"); // "Show a message when scripts are executed\n(Preset, can be changed per vessel)"
		public static string StockMessages = GetLoc("StockMessages"); // "Stock Messages"
		public static string StockMessages_desc = GetLoc("StockMessages_desc"); // "Use the stock message system instead of our own"
		public static string MessageDuration = GetLoc("MessageDuration"); // "Message Duration"
		public static string MessageDuration_desc = GetLoc("MessageDuration_desc"); // "Duration of messages on screen in seconds"

		//
		public static string Preferences_Comfort = GetLoc("Preferences_Comfort"); // "Comfort"
		public static string StressBreakdowns = GetLoc("StressBreakdowns"); // "Stress Breakdowns"
		public static string StressBreakdowns_desc = GetLoc("StressBreakdowns_desc"); // "Kerbals can make mistakes when they're under stress"
		public static string StressBreakdownProbability = GetLoc("StressBreakdownProbability"); // "Stress Breakdown Probability"
		public static string StressBreakdownProbability_desc = GetLoc("StressBreakdownProbability_desc"); // "Probability of one stress induced mistake per year"
		public static string IdealLivingSpace = GetLoc("IdealLivingSpace"); // "Ideal Living Space"
		public static string IdealLivingSpace_desc = GetLoc("IdealLivingSpace_desc"); // "Ideal living space per-capita in m^3"
		public static string FirmGroundFactor = GetLoc("FirmGroundFactor"); // "Firm Ground Factor"
		public static string FirmGroundFactor_desc = GetLoc("FirmGroundFactor_desc"); // "Having something to walk on"
		public static string ExerciseFactor = GetLoc("ExerciseFactor"); // "Exercise Factor"
		public static string ExerciseFactor_desc = GetLoc("ExerciseFactor_desc"); // "Having a treadmill"
		public static string SocialFactor = GetLoc("SocialFactor"); // "Social Factor"
		public static string SocialFactor_desc = GetLoc("SocialFactor_desc"); // "Having more than one crew on a vessel"
		public static string CallHomeFactor = GetLoc("CallHomeFactor"); // "Call Home Factor"
		public static string CallHomeFactor_desc = GetLoc("CallHomeFactor_desc"); // "Having a way to communicate with Kerbin"
		public static string PanoramaFactor = GetLoc("PanoramaFactor"); // "Panorama Factor"
		public static string PanoramaFactor_desc = GetLoc("PanoramaFactor_desc"); // "Comfort factor for having a panorama window"
		public static string PlantsFactor = GetLoc("PlantsFactor"); // "Plants Factor"
		public static string PlantsFactor_desc = GetLoc("PlantsFactor_desc"); // "There is some comfort in tending to plants"

		//
		public static string Preferences_Radiation = GetLoc("Preferences_Radiation"); // "Radiation"
		public static string LifetimeRadiation = GetLoc("LifetimeRadiation"); // "Lifetime Radiation"
		public static string LifetimeRadiation_desc = GetLoc("LifetimeRadiation_desc"); // "Do not reset radiation values for kerbals recovered on kerbin"
		public static string Stormprobability = GetLoc("Stormprobability"); // "Storm probability"
		public static string Stormprobability_desc = GetLoc("Stormprobability_desc"); // "Probability of solar storms"
		public static string stormDurationHours = GetLoc("stormDurationHours"); // "Average storm duration (hours)"
		public static string stormDurationHours_desc = GetLoc("stormDurationHours_desc"); // "Average duration of a sun storm in hours"
		public static string stormRadiation = GetLoc("stormRadiation"); // "Average storm radiation rad/h"
		public static string stormRadiation_desc = GetLoc("stormRadiation_desc"); // "Radiation during a solar storm"
		public static string ShieldingEfficiency = GetLoc("ShieldingEfficiency"); // "Shielding Efficiency"
		public static string ShieldingEfficiency_desc = GetLoc("ShieldingEfficiency_desc"); // "Proportion of radiation blocked by shielding (at max amount)"

		////////////////////////////////////////////////////////////////////
		// Planner UI
		////////////////////////////////////////////////////////////////////
		public static string Harvests = GetLoc("Harvests"); // "Harvests"
		public static string Planner_Targetbody = GetLoc("Planner_Targetbody"); // "Target body"
		public static string Planner_SunlightNominal = GetLoc("Planner_SunlightNominal"); // "In sunlight\n<b>Nominal</b> solar panel output"
		public static string Planner_SunlightSimulated = GetLoc("Planner_SunlightSimulated"); // "In sunlight\n<b>Estimated</b> solar panel output\n<i>Sunlight direction : look at the shadows !</i>"
		public static string Planner_Shadow = GetLoc("Planner_Shadow"); // "In shadow"
		public static string Planner_Targetsituation = GetLoc("Planner_Targetsituation"); // "Target situation"
		public static string Planner_RenderQuote = GetLoc("Planner_RenderQuote"); // "In preparing for space, I have always found that\nplans are useless but planning is indispensable.\nWernher von Kerman"
		public static string Planner_Source = GetLoc("Planner_Source"); // "Source"
		public static string Planner_Flux = GetLoc("Planner_Flux"); // "Flux"
		public static string Planner_Temp = GetLoc("Planner_Temp"); // "Temp"
		public static string Planner_solar = GetLoc("Planner_solar"); // "solar"
		public static string Planner_albedo = GetLoc("Planner_albedo"); // "albedo"
		public static string Planner_body = GetLoc("Planner_body"); // "body"
		public static string Planner_background = GetLoc("Planner_background"); // "background"
		public static string Planner_total = GetLoc("Planner_total"); // "total"
		public static string Planner_pressure = GetLoc("Planner_pressure"); // "pressure"
		public static string Planner_temperature = GetLoc("Planner_temperature"); // "temperature"
		public static string Planner_atmospheric = GetLoc("Planner_atmospheric"); // "atmospheric"
		public static string Planner_difference = GetLoc("Planner_difference"); // "difference"
		public static string Planner_difference_desc = GetLoc("Planner_difference_desc"); // "difference between external and survival temperature"
		public static string Planner_atmosphere = GetLoc("Planner_atmosphere"); // "atmosphere"
		public static string Planner_atmosphere_yes = GetLoc("Planner_atmosphere_yes"); // "yes"
		public static string Planner_atmosphere_no = GetLoc("Planner_atmosphere_no"); // "no"
		public static string Planner_shadowtime = GetLoc("Planner_shadowtime"); // "shadow time"
		public static string Planner_shadowtime_desc = GetLoc("Planner_shadowtime_desc"); // "the time in shadow\nduring the orbit"
		public static string Planner_ELECTRICCHARGE = GetLoc("Planner_ELECTRICCHARGE"); // "ELECTRIC CHARGE"
		public static string Planner_storage = GetLoc("Planner_storage"); // "storage"
		public static string Planner_consumed = GetLoc("Planner_consumed"); // "consumed"
		public static string Planner_produced = GetLoc("Planner_produced"); // "produced"
		public static string Planner_duration = GetLoc("Planner_duration"); // "duration"
		public static string Planner_STRESS = GetLoc("Planner_STRESS"); // "STRESS"
		public static string Planner_volumepercapita = GetLoc("Planner_volumepercapita"); // "volume per-capita:"
		public static string Planner_ideallivingspace = GetLoc("Planner_ideallivingspace"); // "ideal living space:"
		public static string Planner_livingspace = GetLoc("Planner_livingspace"); // "living space"
		public static string Planner_comfort = GetLoc("Planner_comfort"); // "comfort"
		public static string Planner_analyzerpressurized1 = GetLoc("Planner_analyzerpressurized1"); // "Free roaming in a pressurized environment is\nvastly superior to living in a suit."
		public static string Planner_analyzerpressurized2 = GetLoc("Planner_analyzerpressurized2"); // "Being forced inside a suit all the time greatly\nreduces the crews quality of life.\nThe worst part is the diaper."
		public static string Planner_pressurized = GetLoc("Planner_pressurized"); // "pressurized"
		public static string Planner_pressurized_yes = GetLoc("Planner_pressurized_yes"); // "yes"
		public static string Planner_pressurized_no = GetLoc("Planner_pressurized_no"); // "no"
		public static string Planner_lifeestimate = GetLoc("Planner_lifeestimate"); // "duration"
		public static string Planner_surface = GetLoc("Planner_surface"); // "surface"
		public static string Planner_magnetopause = GetLoc("Planner_magnetopause"); // "magnetopause"
		public static string Planner_innerbelt = GetLoc("Planner_innerbelt"); // "inner belt"
		public static string Planner_outerbelt = GetLoc("Planner_outerbelt"); // "outer belt"
		public static string Planner_interplanetary = GetLoc("Planner_interplanetary"); // "interplanetary"
		public static string Planner_interstellar = GetLoc("Planner_interstellar"); // "interstellar"
		public static string Planner_storm = GetLoc("Planner_storm"); // "storm"
		public static string Planner_RADIATION = GetLoc("Planner_RADIATION"); // "RADIATION"
		public static string Planner_orbit = GetLoc("Planner_orbit"); // "orbit"
		public static string Planner_emission = GetLoc("Planner_emission"); // "emission"
		public static string Planner_activeshielding = GetLoc("Planner_activeshielding"); // "active shielding"
		public static string Planner_shielding = GetLoc("Planner_shielding"); // "shielding"
		//traduce the redundancy metric to string
		public static string Planner_none = GetLoc("Planner_none"); // "none"
		public static string Planner_poor = GetLoc("Planner_poor"); // "poor"
		public static string Planner_okay = GetLoc("Planner_okay"); // "okay"
		public static string Planner_great = GetLoc("Planner_great"); // "great"
		public static string Planner_engineer_tip = GetLoc("Planner_engineer_tip"); // "The engineer on board should\nbe able to handle all repairs"
		public static string Planner_safemode_tip = GetLoc("Planner_safemode_tip"); // "We have a chance of repairing\nsome of the malfunctions remotely"
		public static string Planner_RELIABILITY = GetLoc("Planner_RELIABILITY"); // "RELIABILITY"
		public static string Planner_malfunctions = GetLoc("Planner_malfunctions"); // "malfunctions"
		public static string Planner_malfunctions_tip = GetLoc("Planner_malfunctions_tip"); // "average case estimate\nfor the whole vessel"
		public static string Planner_highquality = GetLoc("Planner_highquality"); // "high quality"
		public static string Planner_highquality_tip = GetLoc("Planner_highquality_tip"); // "percentage of high quality components"
		public static string Planner_redundancy = GetLoc("Planner_redundancy"); // "redundancy"
		public static string Planner_repair = GetLoc("Planner_repair"); // "repair"
		public static string Planner_scrubbingunnecessary = GetLoc("Planner_scrubbingunnecessary"); // "not required"
		public static string Planner_noscrubbing = GetLoc("Planner_noscrubbing"); // "none"
		public static string Planner_insufficientscrubbing = GetLoc("Planner_insufficientscrubbing"); // "inadequate"
		public static string Planner_sufficientscrubbing = GetLoc("Planner_sufficientscrubbing"); // "good"
		public static string Planner_pressurizationunnecessary = GetLoc("Planner_pressurizationunnecessary"); // "not required"
		public static string Planner_nopressurecontrol = GetLoc("Planner_nopressurecontrol"); // "none"
		public static string Planner_insufficientpressurecontrol = GetLoc("Planner_insufficientpressurecontrol"); // "inadequate"
		public static string Planner_sufficientpressurecontrol = GetLoc("Planner_sufficientpressurecontrol"); // "good"
		public static string Planner_HABITAT = GetLoc("Planner_HABITAT"); // "HABITAT"
		public static string Planner_volume = GetLoc("Planner_volume"); // "volume"
		public static string Planner_volume_tip = GetLoc("Planner_volume_tip"); // "volume of enabled habitats"
		public static string Planner_habitatssurface = GetLoc("Planner_habitatssurface"); // "surface"
		public static string Planner_habitatssurface_tip = GetLoc("Planner_habitatssurface_tip"); // "surface of enabled habitats"
		public static string Planner_scrubbing = GetLoc("Planner_scrubbing"); // "scrubbing"
		public static string Planner_pressurization = GetLoc("Planner_pressurization"); // "pressurization"

		////////////////////////////////////////////////////////////////////
		// Automation > Devices
		////////////////////////////////////////////////////////////////////
		public static string Statu_unknown = GetLoc("Statu_unknown"); // "unknown"
		public static string Antenna_statu_unknown = GetLoc("Antenna_statu_unknown"); // "unknown"
		public static string Experiment_on = GetLoc("Experiment_on"); // "on                        //on partinfo.title"
		public static string Experiment_status = GetLoc("Experiment_status"); // "status :"
		public static string Experiment_issue = GetLoc("Experiment_issue"); // "issue :"
		public static string Experiment_sciencevalue = GetLoc("Experiment_sciencevalue"); // "science value :"
		public static string Experiment_completion = GetLoc("Experiment_completion"); // "completion :"
		public static string SolarPanel_deployable = GetLoc("SolarPanel_deployable"); // "solar panel (deployable)"
		public static string SolarPanel_nonretractable = GetLoc("SolarPanel_nonretractable"); // "solar panel (non retractable)"

		////////////////////////////////////////////////////////////////////
		// Class : Storm
		////////////////////////////////////////////////////////////////////
		// #KERBALISM_Storm_msg1 // "The coronal mass ejection hit <<1>> system"
		// #KERBALISM_Storm_msg2 // "Our observatories report a coronal mass ejection directed toward  <<1>> system"
		// #KERBALISM_Storm_msg3 // "The solar storm at <<1>> system is over"
		// #KERBALISM_Storm_msg4 // "The solar storm around <<1>> is over"
		// #KERBALISM_Storm_msg5 // "The coronal mass ejection hit <<1>>"
		// #KERBALISM_Storm_msg6 // "Our observatories report a coronal mass ejection directed toward <<1>>"
		public static string Storm_msg1text = GetLoc("Storm_msg1text"); // "Storm duration:"
		public static string Storm_msg2text = GetLoc("Storm_msg2text"); // "Time to impact:"

		////////////////////////////////////////////////////////////////////
		// Science > ExperimentInfo
		////////////////////////////////////////////////////////////////////
		public static string ExperimentInfo_Unknown = GetLoc("ExperimentInfo_Unknown"); // "Unknown"
		public static string Experimentinfo_Datasize = GetLoc("Experimentinfo_Datasize"); // "Data size"
		public static string Experimentinfo_generatesample = GetLoc("Experimentinfo_generatesample"); // "Will generate a sample."
		public static string Experimentinfo_Samplesize = GetLoc("Experimentinfo_Samplesize"); // "Sample size:"
		public static string Experimentinfo_Samplemass = GetLoc("Experimentinfo_Samplemass"); // "Sample mass:"
		public static string Experimentinfo_Situations = GetLoc("Experimentinfo_Situations"); // "Situations:\n"
		public static string Experimentinfo_Asteroid = GetLoc("Experimentinfo_Asteroid"); // "Asteroid samples can be taken by kerbals on EVA"
		public static string Experimentinfo_scannerarm = GetLoc("Experimentinfo_scannerarm"); // "Analyse with a scanner arm"
		public static string Experimentinfo_smallRoc = GetLoc("Experimentinfo_smallRoc"); // "Collectable on EVA as a sample"
		public static string Experimentinfo_smallRoc2 = GetLoc("Experimentinfo_smallRoc2"); // "Can't be collected on EVA"
																							// #KERBALISM_Experimentinfo_smallRoc3 // "Found on <<1>>'s :"

		////////////////////////////////////////////////////////////////////
		// ???
		////////////////////////////////////////////////////////////////////
		//show warning message when a vessel cross a radiation belt
		// #KERBALISM_BeltWarnings_msg // "<<1>> is crossing <<2>> radiation belt"
		// Remove Symmetry On Visible Resource Switch
		// #KERBALISM_RemoveSymmetrymsg // "Symmetry on <<1>>\nhas been removed because of switching the <<2>> capacity."
		// Notify the user when crop can be harvested
		// #KERBALISM_harvestedready_msg // "On <<1>> the crop is ready to be harvested"
		public static string BeltWarnings_msgSubtext = GetLoc("BeltWarnings_msgSubtext"); // "Exposed to extreme radiation"
		public static string Fittingparticles_msg = GetLoc("Fittingparticles_msg"); // "Fitting particles to signed distance fields"
		public static string ComebackLater_msg = GetLoc("ComebackLater_msg"); // "Come back in a minute"

		// Kerbal belong to a rescue mission
		//eg. we found Bill Kerman He's still alive!
		public static string Rescuemission_msg1 = GetLoc("Rescuemission_msg1"); // "We found"
		public static string Kerbal_Male = GetLoc("Kerbal_Male"); // "He"
		public static string Kerbal_Female = GetLoc("Kerbal_Female"); // "She"
		public static string Rescuemission_msg2 = GetLoc("Rescuemission_msg2"); // "'s still alive!"

		//Messages muted Messages
		public static string Messagesmuted = GetLoc("Messagesmuted"); // "Messages muted"
		public static string Messagesmuted_subtext = GetLoc("Messagesmuted_subtext"); // "Be careful out there"
		public static string Messagesunmuted = GetLoc("Messagesunmuted"); // "Messages unmuted"

		//Kerbal Breakdown messages
		public static string Kerbalmumbling = GetLoc("Kerbalmumbling"); // "$ON_VESSEL$KERBAL has been in space for too long"
		public static string Kerbalmumbling_subtext = GetLoc("Kerbalmumbling_subtext"); // "Mumbling incoherently"
		public static string Kerbalfatfinger = GetLoc("Kerbalfatfinger"); // "$ON_VESSEL$KERBAL is pressing buttons at random on the control panel"
		public static string Kerbalfatfinger_subtext = GetLoc("Kerbalfatfinger_subtext"); // "Science data has been lost"
		public static string Kerbalrage = GetLoc("Kerbalrage"); // "$ON_VESSEL$KERBAL is possessed by a blind rage"
		public static string Kerbalrage_subtext = GetLoc("Kerbalrage_subtext"); // "A component has been damaged"
		public static string Kerbalwrongvalve = GetLoc("Kerbalwrongvalve"); // "$ON_VESSEL$KERBAL opened the wrong valve"
		public static string Kerbalwrongvalve_subtext = GetLoc("Kerbalwrongvalve_subtext"); // "has been lost" //eg.[Resource Name] has been lost

		////////////////////////////////////////////////////////////////////
		// Science
		////////////////////////////////////////////////////////////////////
		//Science messages
		public static string Scienctransmitted_title = GetLoc("Scienctransmitted_title"); // "transmitted"
		public static string Nosciencegain = GetLoc("Nosciencegain"); // "no science gain : we already had this data"
		public static string SciencresultText1 = GetLoc("SciencresultText1"); // "Our researchers will jump on it right now"
		public static string SciencresultText2 = GetLoc("SciencresultText2"); // "This cause some excitement"
		public static string SciencresultText3 = GetLoc("SciencresultText3"); // "These results are causing a brouhaha in R&D"
		public static string SciencresultText4 = GetLoc("SciencresultText4"); // "Our scientists look very confused"
		public static string SciencresultText5 = GetLoc("SciencresultText5"); // "The scientists won't believe these readings"

		//Science Situation
		public static string Situation_None = GetLoc("Situation_None"); // "none"
		public static string Situation_Landed = GetLoc("Situation_Landed"); // "landed"
		public static string Situation_Splashed = GetLoc("Situation_Splashed"); // "splashed"
		public static string Situation_Flyinglow = GetLoc("Situation_Flyinglow"); // "flying low"
		public static string Situation_Flyinghigh = GetLoc("Situation_Flyinghigh"); // "flying high"
		public static string Situation_Spacelow = GetLoc("Situation_Spacelow"); // "space low"
		public static string Situation_SpaceHigh = GetLoc("Situation_SpaceHigh"); // "space high"
		public static string Situation_Surface = GetLoc("Situation_Surface"); // "surface"
		public static string Situation_Flying = GetLoc("Situation_Flying"); // "flying"
		public static string Situation_Space = GetLoc("Situation_Space"); // "space"
		public static string Situation_BodyGlobal = GetLoc("Situation_BodyGlobal"); // "global"
		public static string Situation_biomes = GetLoc("Situation_biomes"); // "(biomes)"

		//Virtual Biome
		public static string Situation_NoBiome = GetLoc("Situation_NoBiome"); // "global"
		public static string Situation_NorthernHemisphere = GetLoc("Situation_NorthernHemisphere"); // "north hemisphere"
		public static string Situation_SouthernHemisphere = GetLoc("Situation_SouthernHemisphere"); // "south hemisphere"
		public static string Situation_InnerBelt = GetLoc("Situation_InnerBelt"); // "inner belt"
		public static string Situation_OuterBelt = GetLoc("Situation_OuterBelt"); // "outer belt"
		public static string Situation_Magnetosphere = GetLoc("Situation_Magnetosphere"); // "magnetosphere"
		public static string Situation_Interstellar = GetLoc("Situation_Interstellar"); // "interstellar"
		public static string Situation_Reentry = GetLoc("Situation_Reentry"); // "reentry"
		public static string Situation_Storm = GetLoc("Situation_Storm"); // "solar storm"

		//Log Manager
		public static string LogMan_LOGS = GetLoc("LogMan_LOGS"); // "LOGS"
		public static string LogMan_ALLLOGS = GetLoc("LogMan_ALLLOGS"); // "ALL LOGS"
		public static string LogMan_nologs = GetLoc("LogMan_nologs"); // "no logs"
		public static string LogMan_ALERT = GetLoc("LogMan_ALERT"); // "ALERT\u0020\u0020\u0020"

		//Flight Logger
		// #KERBALISM_FlightLogger_MaterialFatigue // "<<1>> failed because of material fatigue"
		// #KERBALISM_FlightLogger_Destruction // "<<1>> fuel system leak caused destruction of the engine"
		// #KERBALISM_FlightLogger_Ignition // "<<1>> failure on ignition"

		//Experiment required
		public static string ExperimentReq_OrbitMinInclination = GetLoc("ExperimentReq_OrbitMinInclination"); // "Min. inclination "
		public static string ExperimentReq_OrbitMaxInclination = GetLoc("ExperimentReq_OrbitMaxInclination"); // "Max. inclination "
		public static string ExperimentReq_OrbitMinEccentricity = GetLoc("ExperimentReq_OrbitMinEccentricity"); // "Min. eccentricity "
		public static string ExperimentReq_OrbitMaxEccentricity = GetLoc("ExperimentReq_OrbitMaxEccentricity"); // "Max. eccentricity "
		public static string ExperimentReq_OrbitMinArgOfPeriapsis = GetLoc("ExperimentReq_OrbitMinArgOfPeriapsis"); // "Min. argument of Pe "
		public static string ExperimentReq_OrbitMaxArgOfPeriapsis = GetLoc("ExperimentReq_OrbitMaxArgOfPeriapsis"); // "Max. argument of Pe "
		public static string ExperimentReq_TemperatureMin = GetLoc("ExperimentReq_TemperatureMin"); // "Min. temperature "
		public static string ExperimentReq_TemperatureMax = GetLoc("ExperimentReq_TemperatureMax"); // "Max. temperature "
		public static string ExperimentReq_AltitudeMin = GetLoc("ExperimentReq_AltitudeMin"); // "Min. altitude "
		public static string ExperimentReq_AltitudeMax = GetLoc("ExperimentReq_AltitudeMax"); // "Max. altitude "
		public static string ExperimentReq_RadiationMin = GetLoc("ExperimentReq_RadiationMin"); // "Min. radiation "
		public static string ExperimentReq_RadiationMax = GetLoc("ExperimentReq_RadiationMax"); // "Max. radiation "
		public static string ExperimentReq_VolumePerCrewMin = GetLoc("ExperimentReq_VolumePerCrewMin"); // "Min. vol./crew "
		public static string ExperimentReq_VolumePerCrewMax = GetLoc("ExperimentReq_VolumePerCrewMax"); // "Max. vol./crew "
		public static string ExperimentReq_SunAngleMin = GetLoc("ExperimentReq_SunAngleMin"); // "Min sun-surface angle"
		public static string ExperimentReq_SunAngleMax = GetLoc("ExperimentReq_SunAngleMax"); // "Max sun-surface angle"
		public static string ExperimentReq_SurfaceSpeedMin = GetLoc("ExperimentReq_SurfaceSpeedMin"); // "Min. surface speed "
		public static string ExperimentReq_SurfaceSpeedMax = GetLoc("ExperimentReq_SurfaceSpeedMax"); // "Max. surface speed "
		public static string ExperimentReq_VerticalSpeedMin = GetLoc("ExperimentReq_VerticalSpeedMin"); // "Min. vertical speed "
		public static string ExperimentReq_VerticalSpeedMax = GetLoc("ExperimentReq_VerticalSpeedMax"); // "Max. vertical speed "
		public static string ExperimentReq_SpeedMin = GetLoc("ExperimentReq_SpeedMin"); // "Min. speed "
		public static string ExperimentReq_SpeedMax = GetLoc("ExperimentReq_SpeedMax"); // "Max. speed "
		public static string ExperimentReq_DynamicPressureMin = GetLoc("ExperimentReq_DynamicPressureMin"); // "Min dynamic pressure"
		public static string ExperimentReq_DynamicPressureMax = GetLoc("ExperimentReq_DynamicPressureMax"); // "Max dynamic pressure"
		public static string ExperimentReq_StaticPressureMin = GetLoc("ExperimentReq_StaticPressureMin"); // "Min. pressure "
		public static string ExperimentReq_StaticPressureMax = GetLoc("ExperimentReq_StaticPressureMax"); // "Max. pressure "
		public static string ExperimentReq_AtmDensityMin = GetLoc("ExperimentReq_AtmDensityMin"); // "Min. atm. density "
		public static string ExperimentReq_AtmDensityMax = GetLoc("ExperimentReq_AtmDensityMax"); // "Max. atm. density "
		public static string ExperimentReq_AltAboveGroundMin = GetLoc("ExperimentReq_AltAboveGroundMin"); // "Min ground altitude"
		public static string ExperimentReq_AltAboveGroundMax = GetLoc("ExperimentReq_AltAboveGroundMax"); // "Max ground altitude"
		public static string ExperimentReq_MaxAsteroidDistance = GetLoc("ExperimentReq_MaxAsteroidDistance"); // "Max asteroid distance"
		public static string ExperimentReq_AtmosphereAltMin = GetLoc("ExperimentReq_AtmosphereAltMin"); // "Min atmosphere altitude "
		public static string ExperimentReq_AtmosphereAltMax = GetLoc("ExperimentReq_AtmosphereAltMax"); // "Max atmosphere altitude "
		public static string ExperimentReq_CrewMin = GetLoc("ExperimentReq_CrewMin"); // "Min. crew "
		public static string ExperimentReq_CrewMax = GetLoc("ExperimentReq_CrewMax"); // "Max. crew "
		public static string ExperimentReq_CrewCapacityMin = GetLoc("ExperimentReq_CrewCapacityMin"); // "Min. crew capacity "
		public static string ExperimentReq_CrewCapacityMax = GetLoc("ExperimentReq_CrewCapacityMax"); // "Max. crew capacity "
		public static string ExperimentReq_AstronautComplexLevelMin = GetLoc("ExperimentReq_AstronautComplexLevelMin"); // "Astronaut Complex min level "
		public static string ExperimentReq_AstronautComplexLevelMax = GetLoc("ExperimentReq_AstronautComplexLevelMax"); // "Astronaut Complex max level "
		public static string ExperimentReq_TrackingStationLevelMin = GetLoc("ExperimentReq_TrackingStationLevelMin"); // "Tracking Station min level "
		public static string ExperimentReq_TrackingStationLevelMax = GetLoc("ExperimentReq_TrackingStationLevelMax"); // "Tracking Station max level "
		public static string ExperimentReq_MissionControlLevelMin = GetLoc("ExperimentReq_MissionControlLevelMin"); // "Mission Control min level "
		public static string ExperimentReq_MissionControlLevelMax = GetLoc("ExperimentReq_MissionControlLevelMax"); // "Mission Control max level "
		public static string ExperimentReq_AdministrationLevelMin = GetLoc("ExperimentReq_AdministrationLevelMin"); // "Administration min level "
		public static string ExperimentReq_AdministrationLevelMax = GetLoc("ExperimentReq_AdministrationLevelMax"); // "Administration max level "
		public static string ExperimentReq_Part = GetLoc("ExperimentReq_Part"); // "Need part "
		public static string ExperimentReq_Module = GetLoc("ExperimentReq_Module"); // "Need module "

		//Vessel Recovery Window
		public static string VesselRecovery_title = GetLoc("VesselRecovery_title"); // "recovery "
		public static string VesselRecovery_info = GetLoc("VesselRecovery_info"); // "SCIENCE RECOVERED "
		public static string VesselRecovery_CREDITS = GetLoc("VesselRecovery_CREDITS"); // "CREDITS"
		public static string VesselRecovery_OKbutton = GetLoc("VesselRecovery_OKbutton"); // "OK"

	}
}